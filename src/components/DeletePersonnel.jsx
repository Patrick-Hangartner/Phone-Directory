import axios from 'axios';

const DeletePersonnel = ({ personnel, setPersonnelList }) => {
    const handleClick = () => {
        axios.delete(`https://my-api.com/personnel/${personnel.id}`)
            .then(response => {
                setPersonnelList(prevPersonnelList => prevPersonnelList.filter(p => p.id !== personnel.id));
            })
            .catch(error => console.log(error));
    };

    return <button onClick={handleClick}>Delete Personnel</button>;
};

export default DeletePersonnel
