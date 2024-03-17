import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Register } from "./components/account/register";
import { Login } from "./components/account/login";

const AppRoutes = [
  {
    index: true,
    element: <Login />
  },
  {
    path:'/register',
    element : <Register />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  },
];

export default AppRoutes;
