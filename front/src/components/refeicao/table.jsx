import React from 'react';
import { bindDefault } from '../../config/binders';

import BtnGroupActions from './actions';
import BootstrapTable from 'react-bootstrap-table-next';

import paginationFactory from 'react-bootstrap-table2-paginator';

export default bindDefault('refeicoes')(({ refeicoes = require('./mock.json').refeicoes }) => {

    const columns = [
        {
            dataField: 'codigo',
            text: 'Código',
            sort: true
        },
        {
            dataField: 'cliente',
            text: 'Cliente',
            sort: true
        },
        {
            dataField: 'diaRefeicao',
            text: 'Dia da refeição',
            sort: true
        },
        {
            dataField: 'tipoRefeicao',
            text: 'Tipo da refeição',
            sort: true
        },
        {
            dataField: 'actions',
            text: 'Ações',
            headerStyle: { width: 120 }
        }
    ];

    const _refeicoes = (refeicoes || []).map(refeicao => ({
        ...refeicao,
        actions: <BtnGroupActions refeicao={refeicao} />
    }));

    return <BootstrapTable striped condensed keyField="codigo" data={_refeicoes} columns={columns} noDataIndication={_refeicoes ? 'Não há refeições!' : <i className="fa fa-cog fa-2x fa-spin fa-fw" />} pagination={paginationFactory()} />
});