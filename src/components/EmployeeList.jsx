import React, { useState, useEffect } from 'react';
import axios from 'axios';

const EmployeeList = () => {
   
    const [employees, setEmployees] = useState([]);
    
    const [filteredEmployees, setFilteredEmployees] = useState([]);
    
    const [selectedDepartment, setSelectedDepartment] = useState('');
    
    const [searchTerm, setSearchTerm] = useState('');
   
    const titleOrder = ['VP', 'Director', 'Assistant Director', 'Manager', 'Assistant Manager', 'Supervisor'];

    
    useEffect(() => {
        axios.get('https://my-api.com/employees')
            .then(response => setEmployees(response.data))
            .catch(error => console.log(error));
    }, []);

    
    useEffect(() => {
       
        let filteredEmployees = employees.filter(employee =>
            employee.department === selectedDepartment &&
            (employee.firstName.includes(searchTerm) || employee.lastName.includes(searchTerm))
        );

       
        filteredEmployees.sort((a, b) => {
            if (a.title === b.title) {
               
                return a.lastName.localeCompare(b.lastName);
            } else {
               
                return titleOrder.indexOf(a.title) - titleOrder.indexOf(b.title);
            }
        });
        setFilteredEmployees(filteredEmployees);
    }, [selectedDepartment, searchTerm, employees]);

    return (
        <div>
            <DepartmentSelect setSelectedDepartment={setSelectedDepartment} /> 
            <Search setSearchTerm={setSearchTerm} />
            <EmployeeTable employees={filteredEmployees} />
        </div>
    );
};


const DepartmentSelect = ({ setSelectedDepartment }) => {
    const [departments, setDepartments] = useState([]);

    useEffect(() => {
        axios.get('https://my-api.com/departments')
            .then(response => setDepartments(response.data))
            .catch(error => console.log(error));
    }, []);

    return (
        <select onChange={e => setSelectedDepartment(e.target.value)}>
            <option value="">All Departments</option>
            <option value="IT">IT</option>
            <option value="Sale">Sale</option>
            <option value="HR">HR</option>
            {departments.map(department => (
                <option key={department} value={department}>{department}</option>
            ))}
        </select>
    );
};

const Search = ({ setSearchTerm }) => {
    const handleClick = () => {
        
    }
    return (
        <div>
            <input type="text" placeholder="Search by first name, last name, extension, or phone number" onChange={e => setSearchTerm(e.target.value)} />
            <button onClick={handleClick}>Search</button>
        </div>
    );
};


        
        const EmployeeTable = ({ employees }) => {
        return (
        <table>
        <thead>
        <tr>
        <th>First Name</th>
        <th>Last Name</th>
        <th>Department</th>
        <th>Title</th>
        <th>Email</th>
        <th>Mobile Phone</th>
        <th>Office Phone</th>
        <th>Ext</th>
        <th>Notes</th>
        </tr>
        </thead>
        <tbody>
        {employees.map(employee => (
        <tr key={employee.id}>
        <td>{employee.firstName}</td>
        <td>{employee.lastName}</td>
        <td>{employee.department}</td>
        <td>{employee.title}</td>
        <td>{employee.email}</td>
        <td>{employee.mobilePhone}</td>
        <td>{employee.officePhone}</td>
        <td>{employee.ext}</td>
        <td>{employee.notes}</td>
        </tr>
        ))}
        </tbody>
        </table>
        );
        };
        
    

export default EmployeeList;
