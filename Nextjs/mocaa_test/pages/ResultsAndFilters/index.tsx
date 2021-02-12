import Table from '@material-ui/core/Table';
import { makeStyles } from '@material-ui/core/styles';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import styles from './../../styles/ResultsAndFilters.module.css';
import { gql, useMutation } from '@apollo/client';
import { useEffect, useState } from 'react';
import { collapseTextChangeRangesAcrossMultipleVersions } from 'typescript';


const SORT_EMPLOYEES_BY = gql`
mutation sortEmployeeBy($sort:String,$to:String,$from:String,$name:String)
{
    sortEmployeeBy(sort:$sort,to:$to,from:$from,name:$name)
   {
       code
       message
       {
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
const FILTER_EMPLOYEES_BY_AGE = gql`
mutation filterEmployeeByAge($to:String,$from:String,$sort:String,$name:String)
{
    filterEmployeeByAge(to:$to,from:$from,sort:$sort,name:$name)
   {
       code
       message
       {
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


const useStyles = makeStyles({
    table: {
        minWidth: 'auto',
    },
});
const ResultsAndFilters = ({ resetPage, setResetPage, data = [], setSearchByName, setAgeFilter, setSortBy, searchInputValue }) => {

    const [defaultToValue, setDefaultToValue] = useState('');
    const [defaultFromValue, setDefaultFromValue] = useState('');
    const [sortValue, setSortValue] = useState('choose_sort');
    const [defaultSortValue, setDefaultSortValue] = useState('choose_sort');
    let p = 'pick_age';
    let ageTo = [];
    ageTo.push(<option key={'a' + 0} value={'pick_age'} >Pick Age</option>);
    for (let i = 1; i <= 100; i++) {
        ageTo.push(<option key={'a' + i} value={i} >{i}</option>);
    }


    const [_filterEmployeeByAge] = useMutation(FILTER_EMPLOYEES_BY_AGE, {
        onError(err) {
            console.log(err);
            alert(err);
        },
        update(proxy, result) {
            console.log(result);
            if (result.data.filterEmployeeByAge.code !== 200) {
                alert(result.data.filterEmployeeByAge.message);
                return;
            }
            setSearchByName(result.data.filterEmployeeByAge.message);

        }

    });
    const [sortEmploeesBy, { loading: mutationLoading, error: mutationError },] = useMutation(SORT_EMPLOYEES_BY, {
        onError(err) {
            console.log(err);
            alert(err);
        },
        update(proxy, result) {
            console.log(result);
            if (result.data.sortEmployeeBy.code !== 200) {
                alert(result.data.sortEmployeeBy.message);
                return;
            }
            setSearchByName(result.data.sortEmployeeBy.message);
        }

    });
    const resetSelect = () => {
        setDefaultToValue('pick_age');
        setDefaultFromValue('pick_age');

    }
    const sortEmployees = (e) => {
        if (e.target.value === sortValue)
            return;
        setDefaultSortValue(e.target.value);
        setSortValue(e.target.value);
        setSortBy(e.target.value);
        sortEmploeesBy({
            variables: {
                name: searchInputValue,
                sort: e.target.value,
                to: (defaultToValue === 'pick_age' ? '' : defaultToValue),
                from: (defaultFromValue === 'pick_age' ? '' : defaultFromValue)
            }
        });


    }
    const resetComponents = () => {
        resetSelect();
        setDefaultSortValue('choose_sort');
    }

    const setToAge = (e) => {

        if (isNaN(e.target.value)) {
            alert('is not a value');
            return;
        }


        setDefaultToValue(e.target.value);

    }
    const setFromAge = (e) => {
        if (isNaN(e.target.value)) {

            return;
        }

        if (isNaN(parseInt(defaultToValue))) {
            alert("please select To");
            return;
        }
        setDefaultFromValue(e.target.value);
        if (parseInt(e.target.value) < parseInt(defaultToValue)) {
            alert('wrong range');
            return;
        }
        console.log('defaultToValue', defaultToValue);
        setAgeFilter({ to: defaultToValue, from: defaultFromValue });
        _filterEmployeeByAge({ variables: { name: searchInputValue, to: defaultToValue, from: e.target.value, sort: sortValue } });


    }

    const classes = useStyles();
    useEffect(() => {
        if (resetPage) {
            resetComponents();
            setResetPage(false);
        }

    })

    return (
        <div className={styles.results_and_filter_container}>

            <div className={styles.filters}>
                <div className = {styles.filters_container}>
                    <h2>FILTERS</h2>
                    <fieldset className={styles.age}>
                        <legend>AGE</legend>
                        <label>To:</label>
                        <select value={defaultToValue} onFocus={resetSelect} onChange={setToAge}>
                            {
                                ageTo
                            }
                        </select>
                        <label>From:</label>

                        <select onChange={setFromAge} value={defaultFromValue}>
                            {
                                ageTo
                            }
                        </select>
                    </fieldset>
                </div>
            </div>

            <div className={styles.results}>
                <div className={styles.select_container}>
                    <label>{'Sort By:   '}</label>
                    <select value={defaultSortValue} onChange={sortEmployees} >
                        <option key='1aa' value='choose_sort'>Choose Sort</option>
                        <option key='1a' value='first_name' >First Name</option>
                        <option key='1b' value='last_name' >Last Name</option>
                        <option key='1c' value='age' >Age</option>
                        <option key='1d' value='email' >Email</option>
                        <option key='1e' value='title' >Title</option>
                        <option key='1f' value='start_date' >Start Date</option>
                    </select>
                </div>
                <TableContainer component={Paper}>
                    <Table className={classes.table} size="small" aria-label="a dense table">
                        <TableHead>
                            <TableRow>
                                <TableCell>Id</TableCell>
                                <TableCell align="right">First Name</TableCell>
                                <TableCell align="right">Middle Name</TableCell>
                                <TableCell align="right">Last Name</TableCell>
                                <TableCell align="right">Age</TableCell>
                                <TableCell align="right">Email</TableCell>
                                <TableCell align="right">Title</TableCell>
                                <TableCell align="right">Start Date</TableCell>

                            </TableRow>
                        </TableHead>
                        <TableBody>

                            {data.map((row, index) => (
                                <TableRow key={index}>
                                    <TableCell component="th" scope="row">
                                        {row.id}
                                    </TableCell>
                                    <TableCell scope="row">
                                        {row.first_name}
                                    </TableCell>
                                    <TableCell align="right">{row.middle_name}</TableCell>
                                    <TableCell align="right">{row.last_name}</TableCell>
                                    <TableCell align="right">{row.age}</TableCell>
                                    <TableCell align="right">{row.email}</TableCell>
                                    <TableCell align="right">{row.title}</TableCell>
                                    <TableCell align="right">{row.start_date}</TableCell>

                                </TableRow>
                            ))}
                        </TableBody>
                    </Table>
                </TableContainer>
            </div>
        </div>


    )
}

export default ResultsAndFilters;