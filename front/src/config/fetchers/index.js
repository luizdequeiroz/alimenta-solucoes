import { put } from 'redux-saga/effects';

const ApiDefault = process.env.NODE_ENV !== 'production' ? process.env.REACT_APP_API_DEVELOP : process.env.REACT_APP_API_PRODUCT;

export default function* _fetch(API, endpoint,
    returnReduceKey,
    parametros = {},
    treatment,
    callback) {

    let retorno;

    try {
        const url = `${API || ApiDefault}/${endpoint}`;
        const data = yield fetch(url, parametros);
        if (data.ok) {
            if (data.status === 200) {
                retorno = yield data.json();
            } else {
                retorno = {
                    sucesso: true
                };
            }
        } else {
            retorno = { // TODO
                stack: 'Error',
                erros: [
                    "Erro de comunicação com o servidor."
                ]
            };
        }

        if (callback) {
            yield put(callback);
        }
    } catch (error) {

        retorno = { // TODO
            stack: error,
            erros: [
                "Erro de comunicação com o servidor."
            ]
        };

        // retorno = error; // TODO
        yield put(callback[0]);
    }

    if (!retorno.sucesso && !retorno.stack) { // TODO
        retorno = {
            sucesso: true,
            retorno: retorno
        };
    }

    yield put({ type: 'set_value', payload: { key: returnReduceKey, value: retorno, treatment } });
}