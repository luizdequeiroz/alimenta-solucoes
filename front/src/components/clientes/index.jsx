import React, { useState, useEffect } from 'react';
import ClienteTable from './table';
import PesquisarClienteForm from "./pesquisarClienteForm";
import ClienteForm from "./clienteForm";
import { bindDefault } from '../../config/binders';

import ToolkitProvider from 'react-bootstrap-table2-toolkit';
import { treatDefault as treatment } from '../../treatments';

import { API_DOTNET } from '../../utils';

function Clientes({ get, cliente, }) {
    const [novoCliente, setNovoCliente] = useState(false);
    const [visible, setVisible] = useState(false);

    useEffect(() => {
        get('Clientes', 'clientes', { api: API_DOTNET, treatment });
    }, [get]);

    const propsCollapse = {
        style: (novoCliente || cliente) && { cursor: 'pointer' },
        onClick: (novoCliente || cliente) && (() => setVisible(!visible))
    };

    return (
        <div className="container-fluid">
            <div className="row">
                <div className="col-md-12">
                    <div className="card">
                        <div className="card-header card-header-primary" {...propsCollapse}>
                            <h4 className="card-title">Gerenciamento de clientes</h4>
                        </div>
                        {(!novoCliente && !cliente) || visible ?
                            <div className="card-body">
                                <ToolkitProvider search>{props => (
                                    <div>
                                        <PesquisarClienteForm key={cliente && cliente.id} onNovoCliente={setNovoCliente} searchProps={props.searchProps} />
                                        <div style={{ marginTop: '40px' }}>
                                            <ClienteTable baseProps={props.baseProps} />
                                        </div>
                                    </div>
                                )}</ToolkitProvider>
                            </div>
                            : <div className="card-body" />}
                    </div>
                </div>
            </div>
            <div className="row">
                <div className="col-md-12">
                    <div className="card">
                        <div className="card-header card-header-primary">
                            <h4 className="card-title">{(novoCliente || cliente) ? `${novoCliente ? 'Cadastrar' : 'Editar'} cliente` : 'Selecione um cliente acima ou clique em Novo cliente...'}</h4>
                        </div>
                        <div className="card-body">
                            {(novoCliente || cliente) && <ClienteForm key={cliente && cliente.id} onNovoCliente={flag => setNovoCliente(flag)} />}
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default bindDefault('cliente')(Clientes);