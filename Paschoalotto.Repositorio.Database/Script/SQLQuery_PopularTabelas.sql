
use [PaschoalottoDB] 

SET IDENTITY_INSERT [PaschoalottoDB].[provedordados].[DividaCliente] ON 
INSERT INTO [PaschoalottoDB].[provedordados].[DividaCliente] (Id, Guid, ClienteID, DataVencimento, Valor) Values(1, NEWID(),1,'2020-08-13',3000)
SET IDENTITY_INSERT [PaschoalottoDB].[provedordados].[DividaCliente] OFF 

SET IDENTITY_INSERT [PaschoalottoDB].[provedordados].[TipoJuros] ON 
INSERT INTO [PaschoalottoDB].[provedordados].[TipoJuros] (Id, Guid, TipoJuros,  Valor, Criacao, Alteracao) Values(1, NEWID(), 1 ,0.2, GETDATE(), GETDATE())
SET IDENTITY_INSERT [PaschoalottoDB].[provedordados].[TipoJuros] OFF 


SET IDENTITY_INSERT [PaschoalottoDB].[provedordados].[Propostas] ON 
INSERT INTO [PaschoalottoDB].[provedordados].[Propostas] (Id, Guid, JurosId,  DividaId, DataProposta, QtdMaximaParcelas, ContatoColaborador, PorcentagemComissao, Status) Values(1, NEWID(), 1, 1, GETDATE(), 3, '(XX) XXXX-XXXX', 10,1)
SET IDENTITY_INSERT [PaschoalottoDB].[provedordados].[Propostas] OFF 

SELECT * FROM [PaschoalottoDB].[provedordados].[DividaCliente]
SELECT * FROM [PaschoalottoDB].[provedordados].[TipoJuros]
SELECT * FROM [PaschoalottoDB].[provedordados].[Propostas]
SELECT * FROM [PaschoalottoDB].[provedordados].[AcordoCliente]


