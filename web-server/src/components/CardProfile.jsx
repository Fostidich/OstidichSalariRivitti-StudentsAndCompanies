import { useState, useEffect } from 'react';
import Cookies from 'js-cookie';
const API_SERVER_URL = import.meta.env.VITE_API_SERVER_URL;
function CardProfile (){
    const [username, setUsername] = useState('');
    const [email, setEmail] = useState('');
    const [userType, setUserType] = useState('');

    useEffect(() => {
        const downloadInformations = async () => {
            try {
                const token = Cookies.get('token');
                const response = await fetch(`${API_SERVER_URL}/api/profile`, {
                    method: 'GET',
                    headers: {
                        'Authorization': `Bearer ${token}`, // Invia il token nell'header Authorization
                    },
                });

                if (response.status === 200){
                    const data = await response.json();

                    setUsername(data.username);
                    setEmail(data.email);
                    setUserType(data.userType);
                }else
                    console.error('Error checking profile informations:', response.status);

            } catch (error) {
                console.error('Error checking profile informations:', error);
            }
        };

        downloadInformations();
    }, []);

    return (

        <div className="bg-white flex flex-col rounded-xl p-6 border items-center">
            <div className="flex flex-col pb-4">
                <img className="w-24 h-24 border rounded-full"
                     src={"https://static.vecteezy.com/system/resources/previews/020/911/733/non_2x/profile-icon-avatar-icon-user-icon-person-icon-free-png.png"}/>
            </div>
            <div className="flex flex-col items-center gap-2">
                <p className="text-lg font-bold">{username}</p>
                <p className="text-lg font-light">{email}</p>
                <p className="text-lg font-light">{userType}</p>
            </div>
            <button className=" text-white rounded-xl underline text-blue-500">Edit</button>
        </div>

    );



}
export default CardProfile;