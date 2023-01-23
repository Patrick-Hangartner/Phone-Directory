import React from 'react';
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';
import AdminPortal from './components/AdminPortal';
import EmployeeList from './components/EmployeeList';



const App = () => {
    return (
        <Router>
            <div>
                <h1>Welcome to the Home Page</h1>
                <Link to="/admin">
                    <button>Admin Portal</button>
                </Link>
                <Link to="/employees">
                    <button>Employee List</button>
                </Link>

                <Routes>
                    <Route path="/admin" element={<AdminPortal />} />
                    <Route path="/employees" element={<EmployeeList />} />
                </Routes>
            </div>
        </Router>
    );
};

export default App;

