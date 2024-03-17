import axios from 'axios'
import { _APP_URL } from '../settings/globalConstant';
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

export const registerUserService = (model) => {
    const path = _APP_URL + 'Account/register';
    axios.post(path, model).then(
        (response) => {
            var result = response.data;
            console.log(result);
            toast(result);

        },
        (error) => {
            console.log(error);
            const errors = error?.response?.data;
            console.log("errors", errors);
            let message = '';
            if (errors) {
                errors.map((value) => (
                    message = message + value.description + '\r\n'
                ))
            }
            if (message) {
                console.log(message);
                toast(message);
            }
        }
    );
}

export const loginUserService = (model) => {
    const path = _APP_URL + 'Account/login';
    console.log('model', model);
    console.log('path', path);
    axios.post(path, model).then(
        (response) => {
            var result = response.data;
            toast(result);

        },
        (error) => {
            const errors = error?.response?.data;
            if (errors) {
                toast(errors);
            }
        }
    );
}