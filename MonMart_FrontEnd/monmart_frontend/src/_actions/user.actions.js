import { useSetRecoilState } from 'recoil';
import { history, useFetchWrapper } from '_utilities';
import { authAtom, usersAtom } from '_state';

export { useUserActions };

function useUserActions () {
    const baseUrl = `${process.env.REACT_APP_API_URL}/users`;
    const fetchWrapper = useFetchWrapper();
    const setAuth = useSetRecoilState(authAtom);
    const setUsers = useSetRecoilState(usersAtom); 

    return {
        login,
        logout,
        getAllUsers
    }

    function login(username, password) {
        return fetchWrapper.post(`${baseUrl}/authenticate`, { username, password })
            .then(user => {
                localStorage.setItem('user', JSON.stringify(user));
                setAuth(user);

                const { from } = history.location.state || { from: { pathname: '/' } };
                history.push(from);
            });
    }

    function logout() {
        localStorage.removeItem('user');
        setAuth(null);
        history.push('/login');
    }

    function getAllUsers() {
        return fetchWrapper.get(baseUrl).then(setUsers);
    }
    
}

