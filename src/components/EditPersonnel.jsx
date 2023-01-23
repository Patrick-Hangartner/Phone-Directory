import { useFormik } from 'formik';
import axios from 'axios';

const UpdatePersonnel = ({ personnel, setPersonnelList }) => {
    const formik = useFormik({
        initialValues: {
            firstName: personnel.firstName,
            lastName: personnel.lastName,
            extension: personnel.extension,
            phoneNumber: personnel.phoneNumber
        },
        onSubmit: values => {
            axios.put(`https://my-api.com/personnel/${personnel.id}`, values)
                .then(response => {
                    setPersonnelList(prevPersonnelList => {
                        const updatedPersonnel = response.data;
                        return prevPersonnelList.map(p => p.id === personnel.id ? updatedPersonnel : p);
                    });
                })
                .catch(error => console.log(error));
        }
    });

    return (
        <form onSubmit={formik.handleSubmit}>
            <label>
                First Name:
                <input type="text" name="firstName" onChange={formik.handleChange} value={formik.values.firstName} />
            </label>
            <label>
                Last Name:
                <input type="text" name="lastName" onChange={formik.handleChange} value={formik.values.lastName} />
            </label>
            <label>
                Extension:
                <input type="text" name="extension" onChange={formik.handleChange} value={formik.values.extension} />
            </label>
            <label>
                Phone Number:
                <input type="text" name="phoneNumber" onChange={formik.handleChange} value={formik.values.phoneNumber} />
            </label>
            <button type="submit">Update Personnel</button>
        </form>
    );
};

export default UpdatePersonnel;
