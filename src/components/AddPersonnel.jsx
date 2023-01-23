import { useFormik } from 'formik';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';


const AddPersonnel = () => {
    const formik = useFormik({
        initialValues: {
            firstName: '',
            lastName: '',
            title: '',
            department : '',
            email : '',
            officePhone : '',
            extension: '',
            phoneNumber: ''
        },
        onSubmit: values => {
            axios.post('http://localhost:7142/api/employee', values)
                .then(response => {
                    
                })
                .catch(error => console.log(error));
        }
    });

    return (
        <form className="bg-light p-3" onSubmit={formik.handleSubmit}>
        <div className="form-group">
            <label>First Name:</label>
            <input className="form-control" type="text" name="firstName" onChange={formik.handleChange} value={formik.values.firstName} />
        </div>
        <div className="form-group">
            <label>Last Name:</label>
            <input className="form-control" type="text" name="lastName" onChange={formik.handleChange} value={formik.values.lastName} />
        </div>
        <div className="form-group">
            <label>Title:</label>
            <input className="form-control" type="text" name="title" onChange={formik.handleChange} value={formik.values.title} />
        </div>
        <div className="form-group">
            <label>Department:</label>
            <input className="form-control" type="text" name="department" onChange={formik.handleChange} value={formik.values.department} />
        </div>
        <div className="form-group">
            <label>Email:</label>
            <input className="form-control" type="text" name="email" onChange={formik.handleChange} value={formik.values.email} />
        </div>
        <div className="form-group">
            <label>Office Phone:</label>
            <input className="form-control" type="text" name="officePhone" onChange={formik.handleChange} value={formik.values.officePhone} />
        </div>
        <div className="form-group">
            <label>Extension:</label>
            <input className="form-control" type="text" name="extension" onChange={formik.handleChange} value={formik.values.extension} />
        </div>
        <div className="form-group">
            <label>Phone Number:</label>
            <input className="form-control" type="text" name="phoneNumber" onChange={formik.handleChange} value={formik.values.phoneNumber} />
        </div>
        <button className="btn btn-primary" type="submit">Add Personnel</button>
    </form>
    );
};

export default AddPersonnel;