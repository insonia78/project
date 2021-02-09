import Head from 'next/head'
import { useState } from 'react';
import styles from '../styles/Home.module.css'
import SearchIcon from '@material-ui/icons/Search';
import { gql, useMutation } from '@apollo/client';
import ResultsAndFilters from './ResultsAndFilters';


const FIND_EMPLOYEE = gql`
mutation searchEmployer($name:String,$to:String,$from:String,$sort:String)
{
   searchEmployer(name:$name,to:$to,from:$from,sort:$sort)
   {
       code
       message{
       first_name
       middle_name
       last_name
       age
       email
       id
       start_date
       title
       }
   }
}
`;
const ALL_EMPLOYEES = gql`
mutation getAllEmployees
{
  getAllEmployees
   {
       code
       message{
       first_name
       middle_name
       last_name
       age
       email
       id
       start_date
       title
       }
   }
}
`;

export default function Home() {

  const [searchInputValue, setSearchInputValue] = useState("");
  const [searchByName, setSearchByName] = useState([]);
  const [switchDisplay, setSwitchDisplay] = useState(false);
  const [ageFilter,setAgeFilter] = useState({to:'',from:''});
  const [resetPage,setResetPage ] = useState(false);
  const[sortBy,setSortBy] = useState('choose_sort');

  const [getEmployees, { loading: mutationLoading, error: mutationError },] = useMutation(FIND_EMPLOYEE, {
    onError(err) {
      console.log(err);
      alert(err);
    },
    update(proxy, result) {
      if(result.data.searchEmployer.code !== 200)
      {
        alert(result.data.message);
        return;
      }
      if(result.data.searchEmployer.message.length === 0)
      {
         alert('No Data Retreved');
         setSearchByName([]);
      }
      else
        setSearchByName(result.data.searchEmployer.message);
    }

  });

  const [getAllEmployees] = useMutation(ALL_EMPLOYEES, {
    onError(err) {
      console.log(err);
      alert(err);
    },
    update(proxy, result) {
      console.log(result);
      if(result.data.getAllEmployees.code !== 200)
      {
        alert(result.data.getAllEmployees.message);
        return;
      }
      if(result.data.getAllEmployees.message.length === 0)
      {
         alert('No Data Retreved');
         setSearchByName([]);
      }
      else
        setSearchByName(result.data.getAllEmployees.message);
      
    }

  });

  const searchAll = () => {
    setSearchInputValue("");
    setSwitchDisplay(true);
    getAllEmployees();

  }
  const inputValue = (e) => {
    setResetPage(false);
    setSearchInputValue(e.target.value);    
      
    console.log('variables', ageFilter.to , ageFilter.from , sortBy );
    getEmployees({ variables: { name: e.target.value,
      to:ageFilter.to,
      from:ageFilter.from,sort:sortBy} });
  }
  const clearInput = () => {
    setSearchInputValue('');
    getAllEmployees();
    setResetPage(true);

  }



  return (
    <div className={styles.container}>
      <Head>
        <title>Mocaa Test</title>
        <meta name="viewport" content="width=device-width, height=device-height, initial-scale=1.0"></meta>
        <link rel="icon" href="/favicon.ico" />
      </Head>
      <header className={styles.header}>
         {switchDisplay &&
            <>
            <input onFocus={clearInput} placeholder='Search' type='text'
              value={searchInputValue}
              onChange={inputValue}
              className={styles.input_search}              
              />
            </>
            }   

      </header>
      <main className={styles.main}>
       { !switchDisplay && <>
          <div className={styles.search_container}>
            <input onFocus={clearInput} placeholder='Search' type='text'
              value={searchInputValue}
              onChange={inputValue}
              className={styles.input_search}
              list='employees' />
            <datalist defaultValue={'aliment'}
              id="employees">
              {searchByName.map((element, index) =>

                <option key={Math.random() * index} value={`${element.first_name} , ${(element.middle_name !== '' ? (element.middle_name + ',') : "")} ${element.last_name}, ${element.title}, ${element.age}`} >
                </option>

              )}
            </datalist>
            <SearchIcon onClick={searchAll} style={{ cursor: 'pointer', width: '3vw', height: '3vw' }} />
          </div>
        </>}
        {
           switchDisplay && <ResultsAndFilters resetPage={resetPage}  setResetPage={setResetPage} searchInputValue={searchInputValue}   setSortBy={setSortBy} setAgeFilter={setAgeFilter}  data={(searchByName === undefined? []:searchByName)}  setSearchByName={setSearchByName}/>
        }
      </main>
    </div>


  )
}
