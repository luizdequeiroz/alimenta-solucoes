export const treatUserName = (response) => {
    const username = response.retorno && response.retorno.nome;
    sessionStorage.setItem('username', username);
    return username;
}

export const treatDefault = response => response.retorno;

export const treatRefeicoes = response => {
    return response.retorno.groupBy('dataRefeicao', 'refeicoes')
}