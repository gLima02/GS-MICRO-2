# Global Solution - Microservices</br>
## Guilherme Lima Oliveira - RM93401

Modelo de Dados:   API Consumo 


| Campo  | Tipo |Descricao |
| ------------- | ------------- |------------- |
| id  | int  | Identificador único do registro de consumo.   |
| data   | String  | Data e hora do registro no formato ISO 8601.   |
id 	      |            int 	| Identificador único do registro de consumo. 
data 	     |           string |	Data e hora do registro no formato ISO 8601. 
consumoKwh 	|          double 	| Consumo de energia em kWh. 
custo 	     |         double 	| Custo associado ao consumo (em moeda local). 
fonteEnergia 	|        string 	| Fonte de energia utilizada (ex.: solar, eólica). 
emissaoCO2 	   |       double 	| Emissão de CO2 associada ao consumo (em kg). 
localizacao 	  |      string 	| Localização do consumo (ex.: cidade, estado). 
dispositivo 	   |     string 	| Equipamento relacionado ao consumo. 
percentualEnergiaRenovavel |	double |	Percentual de energia proveniente de fontes renováveis.
picoConsumo 	      |  bool |	 Indica se o consumo ocorreu em horário de pico. 
usuarioResponsavel 	|  string |	Nome ou identificador do usuário responsável. 
  
  - Rotas 
1.	[GET] Obter Todos os Registros 
Endpoint:</br>
GET /api/consumo</br> 
Descrição: </br>
Retorna uma lista com todos os registros de consumo.</br> 
2.	[POST] Inserir Registro</br> 
Endpoint: POST /api/consumo </br>
Descrição: </br>
Cria um novo registro de consumo. 

### Evidências

POST CONSUMO

![image](https://github.com/user-attachments/assets/196b3c20-7e4c-48fe-8af3-c6e642d8fe39)

GET CONSUMO

![image](https://github.com/user-attachments/assets/0676cc17-789a-4b11-975f-80f86dcb3496)

STATUS DE FUNCIONAMENTO 

ROTA: /api/Health

![image](https://github.com/user-attachments/assets/e1386d2d-521f-4c10-b34e-b6bef83ea264)
