import React, { Component } from 'react';
import UsersTable from './table';
import UserForm from "./form";
import { bindDefault } from '../../config/binders';
import { API_DOTNET } from '../../utils';
import { treatDefault as treatment } from '../../treatments';

class Users extends Component {

    componentDidMount() {
        const { get } = this.props;

        get('Usuarios', 'usuarios', { api: API_DOTNET, treatment });
    }

    render() {
        const { usuario } = this.props;

        return (
            <div className="container-fluid">
                <div className="row">
                    <div className="col-lg-8 col-md-8">
                        <div className="card">
                            <div className="card-header card-header-primary">
                                <h4 className="card-title">Usuários do sistema</h4>
                            </div>
                            <div className="card-body">
                                <UsersTable />
                            </div>
                        </div>
                    </div>
                    <div className="col-lg-4 col-md-4">
                        <div className="card">
                            <div className="card-header card-header-success">
                                <h4 className="card-title">{usuario ? 'Salvar' : 'Novo'} usuário</h4>
                            </div>
                            <div className="card-body">
                                <UserForm key={usuario && usuario.id} />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

export default bindDefault('usuario')(Users);