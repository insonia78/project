module.exports = class StartCrawler {
  constructor(jsonFile) {
    this.addressesList = [];
    this.linksDone = [];
    this.summaryOfCrawling = {
      Success: [],
      Skyped: [],
      Error: []
    };
    this.jsonFile = jsonFile;
  }

  Init() {
    return this.performCrawling();
  }

  performCrawling() {
    for (let i = 0; i < this.jsonFile.length; i++) {
      this.addressesList.push(this.jsonFile[i].address);
    }
    this.addressesList.sort();
    for (let i = 0; i < this.jsonFile.length; i++) {
      if (
        !this.AddressBinarySearch(
          this.summaryOfCrawling.Success,
          this.jsonFile[i].address
        )
      ) {
        this.summaryOfCrawling.Success.push(this.jsonFile[i].address);
        this.summaryOfCrawling.Success.sort();
      }

      for (let y = 0; y < this.jsonFile[i].links.length; y++) {
        if (
          this.AddressBinarySearch(
            this.addressesList,
            this.jsonFile[i].links[y]
          )
        )
          if (
            this.AddressBinarySearch(
              this.summaryOfCrawling.Success,
              this.jsonFile[i].links[y]
            )
          ) {
            if (
              !this.AddressBinarySearch(
                this.summaryOfCrawling.Skyped,
                this.jsonFile[i].links[y]
              )
            )
              this.summaryOfCrawling.Skyped.push(this.jsonFile[i].links[y]);
          } else this.summaryOfCrawling.Success.push(this.jsonFile[i].links[y]);
        else this.summaryOfCrawling.Error.push(this.jsonFile[i].links[y]);
        this.summaryOfCrawling.Success.sort();
        this.summaryOfCrawling.Skyped.sort();
      }
    }
    console.log(this.summaryOfCrawling);    
    return this.summaryOfCrawling;
  }
  AddressBinarySearch(arr, target) {
    let left = 0;
    let right = arr.length - 1;
    while (left <= right) {
      const mid = left + Math.floor((right - left) / 2);
      if (arr[mid] === target) {
        return true;
      }
      if (arr[mid] < target) {
        left = mid + 1;
      } else {
        right = mid - 1;
      }
    }
    return false;
  }
};
