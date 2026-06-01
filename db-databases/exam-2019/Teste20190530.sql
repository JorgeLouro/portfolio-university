-- Nome, nº
-- BD 23/5/23

-- 4)
SELECT *
FROM Conta
ORDER BY DataAbertura

-- 5)
SELECT C.Nome, C.NIF
FROM Cliente C INNER JOIN TipoCliente TC
	ON C.CodTipoCliente = TC.CodTipoCliente
WHERE DesTipoCliente = 'Empresa'

-- 6)
SELECT C.Nome
FROM Cliente C LEFT JOIN Conta Cn
	ON C.CodCliente = Cn.CodCliente
WHERE Cn.NumConta IS NULL

-- 7)
SELECT M.*, Cli.Nome
FROM Movimento M INNER JOIN Conta C
	ON C.NumConta = M.NumConta
	INNER JOIN Cliente Cli
		ON C.CodCliente = Cli.CodCliente
WHERE DataMovimento BETWEEN '2019-03-01' AND '2019-03-31'
ORDER BY Nome, M.NumConta, NOrdem

-- 8)
SELECT CodCliente, COUNT(*) NContas
FROM Conta
GROUP BY CodCliente

-- 9)
SELECT C.NumConta, DataFecho
FROM Conta C INNER JOIN Movimento M
	ON M.NumConta = C.NumConta
WHERE DataFecho IS NOT NULL
GROUP BY C.NumConta, DataFecho
	HAVING SUM(Valor) = 0

-- 10)
SELECT C.NumConta, C.DataAbertura, C.DataFecho, Cli.Nome,
	   DesTipoCliente, DesTipoConta, SUM(Valor) Saldo
FROM Movimento M
		INNER JOIN Conta C ON C.NumConta = M.NumConta
		INNER JOIN Cliente Cli ON Cli.CodCliente = C.CodCliente
		INNER JOIN TipoConta TC ON C.CodTipoConta = TC.CodTipoConta
		INNER JOIN TipoCliente TCli ON Cli.CodTipoCliente = TCli.CodTipoCliente
GROUP BY C.NumConta, C.DataAbertura, C.DataFecho, Cli.Nome,
	   DesTipoCliente, DesTipoConta
	HAVING SUM(Valor) = 0