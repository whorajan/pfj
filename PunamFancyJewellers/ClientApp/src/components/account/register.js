import './account.css'
import { registerUserService } from "../../services/accountServices"
import { useState } from 'react'


export const Register = () => {

    let userModel = {
        name: "",
        email: "",
        password: "",
        confirmPassword: "",
        acceptedTnC: false,
    }
    const [registerUser, setRegisterUser] = useState(userModel);
    const [modelError, setModelError] = useState({});
    const register = (event) => {
        event.preventDefault();
        registerUserService({ name: registerUser.name, email: registerUser.email, password: registerUser.password });

    }

    const handleChangeEvent = (event) => {
        const { name, value } = event.target;
        setRegisterUser(values => ({ ...values, [name]: value }));
        switch (name) {
            case "name":
                if (registerUser.name.length > 256) {
                    setModelError(values => ({ ...values, "nameError": "Length of Full Name must be within 256 characters" }));
                }
                return;
            default:
                return;
        }
    }

    return (
        <>
            <section >
                <div className="container h-100">
                    <div className="row d-flex justify-content-center align-items-center h-100">
                        <div className="col-lg-12 col-xl-11">
                            <div className="card text-black" style={{ borderRadius: "25px" }}>
                                <div className="card-body p-md-5">
                                    <div className="row justify-content-center">
                                        <div className="col-md-10 col-lg-6 col-xl-5 order-2 order-lg-1">
                                            <p className="text-center h1 fw-bold mb-5 mx-1 mx-md-4 mt-4">Sign up</p>
                                            <form className="mx-1 mx-md-4" onSubmit={register}>
                                                <div className="d-flex flex-row align-items-center mb-4">
                                                    <i className="fas fa-user fa-lg me-3 fa-fw"></i>
                                                    <div className="form-floating flex-fill mb-0 has-validation">
                                                        <input type="text" required name="name" placeholder="Full Name" className="form-control " value={registerUser.name || ''} onChange={(event) => handleChangeEvent(event)} />
                                                        <label htmlFor="name">Full Name</label>
                                                        {registerUser.name.length > 256 && <div className="invalid-feedback">Name must be smaller than 256 characters</div>}
                                                    </div>
                                                </div>

                                                <div className="d-flex flex-row align-items-center mb-4">
                                                    <i className="fas fa-envelope fa-lg me-3 fa-fw"></i>
                                                    <div className="form-floating flex-fill mb-0">
                                                        <input type="email" required name="email" className="form-control" placeholder="Email" value={registerUser.email || ''} onChange={(event) => handleChangeEvent(event)} />
                                                        <label htmlFor="Email">Email</label>
                                                    </div>
                                                </div>

                                                <div className="d-flex flex-row align-items-center mb-4">
                                                    <i className="fas fa-lock fa-lg me-3 fa-fw"></i>
                                                    <div className="form-floating flex-fill mb-0">
                                                        <input type="password" required name="password" className="form-control" placeholder="Password" value={registerUser.password || ''} onChange={(event) => handleChangeEvent(event)} />
                                                        <label htmlFor="password">Password</label>
                                                    </div>
                                                </div>

                                                <div className="d-flex flex-row align-items-center mb-4">
                                                    <i className="fas fa-key fa-lg me-3 fa-fw"></i>
                                                    <div className="form-floating flex-fill mb-0">
                                                        <input type="password" required name="confirmPassword" className="form-control" placeholder="Confirm Password" value={registerUser.confirmPassword || ''} onChange={(event) => handleChangeEvent(event)} />
                                                        <label htmlFor="confirmPassword">Confirm password</label>
                                                    </div>
                                                </div>

                                                <div className="form-check d-flex justify-content-center mb-5">
                                                    <input className="form-check-input me-2" type="checkbox" name="acceptedTnC" id="acceptedTnC" />
                                                    <label className="form-check-label" htmlFor="acceptedTnC">
                                                        I agree all statements in <a href="#!">Terms of service</a>
                                                    </label>
                                                </div>
                                                <div className="d-flex flex-row align-items-center mb-4">
                                                    <button type="submit" className="btn btn-primary btn-lg btn-block w-100">Register</button>
                                                </div>

                                                <div className="divider d-flex align-items-center my-4">
                                                    <p className="text-center fw-bold mx-3 mb-0">Or</p>
                                                </div>

                                                <div className="d-flex flex-row align-items-center justify-content-center justify-content-lg-start">
                                                    <p className="lead fw-normal mb-0 me-3">Connect us with</p>
                                                    <button type="button" className="btn btn-primary btn-floating mx-1">
                                                        <i className="fab fa-facebook-f"></i>
                                                    </button>

                                                    <button type="button" className="btn btn-primary btn-floating mx-1">
                                                        <i className="fab fa-twitter"></i>
                                                    </button>

                                                    <button type="button" className="btn btn-primary btn-floating mx-1">
                                                        <i className="fab fa-linkedin-in"></i>
                                                    </button>
                                                </div>

                                                <div className="text-center text-lg-start mt-4 pt-2">
                                                    <p className="small fw-bold mt-2 pt-1 mb-0">Already have an account? <a href="#"
                                                        className="link-danger">Login</a></p>
                                                </div>

                                            </form>

                                        </div>
                                        <div className="col-md-10 col-lg-6 col-xl-7 d-flex align-items-center order-1 order-lg-2">

                                            <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-registration/draw1.webp"
                                                className="img-fluid" alt="Sample" />

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </>)
}