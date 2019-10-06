import React from 'react';
import { bindDefault } from '../../config/binders';

import BtnGroupActions from './actionsClientes';
import BootstrapTable from 'react-bootstrap-table-next';

import paginationFactory from 'react-bootstrap-table2-paginator';

export default bindDefault('clientes')(({ clientes, baseProps }) => {

    const columns = [
        {
            dataField: 'id',
            text: 'Código',
            sort: true
        },
        {
            dataField: 'nome',
            text: 'Cliente',
            sort: true
        },
        {
            dataField: 'telefone',
            text: 'Contato'
        },
        {
            dataField: 'endereco',
            text: 'Endereço',
            formatter: endereco => {
                const endArray = [];

                if (endereco.logradouro) endArray.push(endereco.logradouro);
                if (endereco.numero) endArray.push(endereco.numero);
                if (endereco.cidade) endArray.push(endereco.cidade);

                const concatenation = endArray.join(', ');

                return `${concatenation} - ${endereco.estado}`
            }
        },
        {
            dataField: 'actions',
            text: 'Ações',
            headerStyle: { width: 120 }
        }
    ];

    const _clientes = (clientes || []).map(cliente => ({
        ...cliente,
        actions: <BtnGroupActions cliente={cliente} />
    }));

    const tableProps = {
        ...baseProps,
        keyField: "id",
        data: _clientes,
        columns: columns
    };

    return <BootstrapTable
        striped
        condensed
        noDataIndication={_clientes ? 'Não há clientes!' : <i className="fa fa-cog fa-2x fa-spin fa-fw" />}
        pagination={paginationFactory({
            sizePerPageList: [{
                text: '5',
                value: 5
            }]
        })}
        {...tableProps}
    />
});