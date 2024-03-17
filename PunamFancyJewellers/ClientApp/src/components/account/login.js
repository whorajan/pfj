import './account.css'
import { loginUserService } from '../../services/accountServices';
import { useState } from 'react';

export const Login = () => {

    const loginSerive = (event) => {
        event.preventDefault();
        loginUserService({ email: user.email, password: user.password });
    }

    const handleChangeEvent = (event) => {
        const { name, value } = event.target;
        setUser(values => ({ ...values, [name]: value }));
    }

    let loginModel = {
        email: "",
        password: "",
        rememberMe: 0,
    }
    const [user, setUser] = useState(loginModel);


    return (
        <>
            <section >
                <div className="container h-100">
                    <div className="row d-flex justify-content-center align-items-center h-100">
                        <div className="col-lg-12 col-xl-11">
                            <div className="card text-black" style={{ borderRadius: "25px" }}>
                                <div className="card-body p-md-5">
                                    <div className="row justify-content-center">
                                        <div className="col-md-10 col-lg-6 col-xl-5 ">
                                            <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-login-form/draw2.webp"
                                                className="img-fluid" alt="login" />
                                        </div>
                                        <div className="col-md-10 col-lg-6 col-xl-5  offset-xl-1">
                                            <form className="mx-1 mx-md-4" onSubmit={loginSerive}>

                                                <div className="d-flex flex-row align-items-center mb-4">
                                                    <i className="fas fa-envelope fa-lg me-3 fa-fw"></i>
                                                    <div className="form-floating flex-fill mb-0">
                                                        <input type="email" required name="email" className="form-control" placeholder="Email" value={user.email} onChange={(event) => handleChangeEvent(event)} />
                                                        <label htmlFor="Email">Email</label>
                                                    </div>
                                                </div>

                                                <div className="d-flex flex-row align-items-center mb-4">
                                                    <i className="fas fa-lock fa-lg me-3 fa-fw"></i>
                                                    <div className="form-floating flex-fill mb-0">
                                                        <input type="password" required name="password" className="form-control" placeholder="Password" value={user.password} onChange={(event) => handleChangeEvent(event)} />
                                                        <label htmlFor="password">Password</label>
                                                    </div>
                                                </div>

                                                <div className="d-flex justify-content-between align-items-center">
                                                    <div className="form-check mb-0">
                                                        <input className="form-check-input me-2" type="checkbox" id="rememberMe" name="rememberMe" value={user.rememberMe} onChange={(event) => handleChangeEvent(event)} />
                                                        <label className="form-check-label" htmlFor="rememberMe">
                                                            Remember me
                                                        </label>
                                                    </div>
                                                    <a href="#!" className="text-body">Forgot password?</a>
                                                </div>

                                                <div className="text-center text-lg-start mt-4 pt-2">
                                                    <button type="submit" className="btn btn-primary btn-lg btn-block w-100">Login</button>


                                                </div>

                                                <div className="divider d-flex align-items-center my-4">
                                                    <p className="text-center fw-bold mx-3 mb-0">Or</p>
                                                </div>

                                                <div className="d-flex flex-row align-items-center justify-content-center justify-content-lg-start">
                                                    <p className="lead fw-normal mb-0 me-3">Sign in with</p>
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
                                                    <p className="small fw-bold mt-2 pt-1 mb-0">Don't have an account? <a href="/register"
                                                        className="link-danger">Register</a></p>
                                                </div>
                                            </form>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </>
    )
}