import Home from './home';
import Users from './users';
import Produtos from './produtos';
import Clientes from './clientes';
import Fornecedores from './fornecedores';
import Refeicoes from './refeicao';
import Receitas from './receita';
import MapaProducao from './mapaProducao';

export default [
    {
        exact: true,
        path: '/',
        icon: 'home',
        name: 'Início',
        component: Home
    },
    {
        path: '/users',
        icon: 'users',
        name: 'Usuários',
        component: Users
    },
    {
        path: '/clientes',
        icon: 'user-circle-o',
        name: 'Clientes',
        component: Clientes
    },
    {
        path: '/produtos',
        icon: 'lemon-o',
        name: 'Produtos',
        component: Produtos
    },
    {
        path: '/fornecedores',
        icon: 'truck',
        name: 'Fornecedores',
        component: Fornecedores
    },
    {
        path: '/refeicoes',
        icon: 'cutlery',
        name: 'Refeições',
        component: Refeicoes
    },
    {
        path: '/receita',
        icon: 'list',
        name: 'Receitas',
        component: Receitas
    },
    {
        path: '/mapaProducao',
        icon: 'map',
        name: 'Mapa',
        component: MapaProducao
    }
];