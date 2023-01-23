import React, { useState, useEffect } from 'react';
import AddPersonnel from './AddPersonnel';
import UpdatePersonnel from './EditPersonnel';
import DeletePersonnel from './DeletePersonnel';
import axios from 'axios';

const AdminPortal = () => {
    const [searchInput, setSearchInput] = useState('');
    const [personnelList, setPersonnelList] = useState([]);
    const [showModel, setShowModel] = useState(false);
    const [selectedPersonnel, setSelectedPersonnel] = useState({});
    const [showAddForm, setShowAddForm] = useState(false);

    useEffect(() => {
        const fetchPersonnelList = async () => {
            try {
                const response = await axios.get('http://localhost:7142/api/employee');
                setPersonnelList(response.data);
            } catch (error) {
                console.log(error);
            }
        }
    
        fetchPersonnelList();
    }, []);
    

    const filteredPersonnel = personnelList.filter(person => {
        return person.firstName.includes(searchInput) ||
               person.lastName.includes(searchInput) ||
               person.extension.includes(searchInput) ||
               person.phoneNumber.includes(searchInput);
    });

    const handleModelOpen = (personnel) => {
        setShowModel(true);
        setSelectedPersonnel(personnel);
    }

    const handleModalClose = () => {
        setShowModel(false);
        setSelectedPersonnel({});
    }

    const handleAddFormToggle = () => {
        setShowAddForm(!showAddForm);
    }

    const SearchInput = ({ setSearchInput }) => {
            const handleClick = () => {
        
            };
            return (
                <div>
                    <input type="text" placeholder="Search by first name, last name, extension, or phone number" onChange={e => setSearchInput(e.target.value)} />
                    <button onClick={handleClick}>Search</button>
                </div>
            );
        };
        
        const PersonnelTable = ({ personnel }) => {
            return (
                <table>
                    <thead>
                        <tr>
                            <th>First Name</th>
                            <th>Last Name</th>
                            <th>Extension</th>
                            <th>Phone Number</th>
                        </tr>
                    </thead>
                    <tbody>
                        {personnel.map(person => (
                            <tr key={person.id}>
                                <td>{person.firstName}</td>
                                <td>{person.lastName}</td>
                                <td>{person.extension}</td>
                                <td>{person.phoneNumber}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            );
        };

    return (
        <div>
            <SearchInput setSearchInput={setSearchInput} />
            <PersonnelTable personnel={filteredPersonnel} handleModalOpen={handleModelOpen} />
            { showAddForm && <AddPersonnel setPersonnelList={setPersonnelList} handleAddFormToggle={handleAddFormToggle} /> }
            <button onClick={handleAddFormToggle}>Add Employee</button>
            { showModel && <UpdatePersonnel personnel={selectedPersonnel} setPersonnelList={setPersonnelList} handleModalClose={handleModalClose} /> }
            { showModel && <DeletePersonnel personnel={selectedPersonnel} setPersonnelList={setPersonnelList} handleModalClose={handleModalClose} /> }
        </div>
    );

};
export default AdminPortal
