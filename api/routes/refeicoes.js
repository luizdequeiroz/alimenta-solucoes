var express = require('express');
var router = express.Router();
var models = require('../models/index');

/**
 * @swagger
 * /refeicao/{clienteId}/{datarefeicao}:
 *   put:
 *     description: Realiza login de usuário, gerando token
 *     parameters:
 *       - name: clienteId
 *         in: path
 *         required: true
 *         type: string
 *       - name: datarefeicao
 *         in: path
 *         required: true
 *         type: string
 *       - name: dados
 *         in: body
 *         required: true
 *         schema:
 *           type: object
 *           properties:
 *             numsequencial:
 *               type: string
 *             diarefeicao:
 *               type: string
 *             tiporefeicao:
 *               type: string
 *             valorrefeicao:
 *               type: string
 *             horarioentrega:
 *               type: string
 *             cliente:
 *               type: string
 *             datarefeicao:
 *               type: string
 *     produces:
 *       - application/json
 *     responses:
 *       200:
 *         description: objeto de retorno de salvamento de refeição
 */
router.put('/:clienteId/:datarefeicao', (req, res, next) => {
    const { clienteId, datarefeicao } = req.params;
    const { numsequencial, tiporefeicao } = req.body;

    if (numsequencial) {
        models.sequelize.query(
            `update tbrefeicao set reftiporefeicao = '${tiporefeicao}' where refnumsequencial = ${numsequencial}`, { type: models.sequelize.QueryTypes.SELECT }
        );
        res.json({
            sucesso: true
        });
    } else {
        models.refeicao.create({ ...req.body, cliente: clienteId, datarefeicao })
            .then(() => res.json({
                sucesso: true
            }))
            .then(error => res.json({
                stack: error,
                erros: [
                    "Erro ao tentar salvar refeição"
                ]
            }));
    }
});

router.delete('/:refeicaoId', (req, res, next) => {
    const { refeicaoId } = req.params;

    models.sequelize.query(
        `delete from tbrefeicao where refnumsequencial = ${refeicaoId}`, { type: models.sequelize.QueryTypes.SELECT }
    );
    res.json({
        sucesso: true
    });
});

module.exports = router;