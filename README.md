- Guilherme Lima Oliveira RM93401

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
Endpoint: GET /api/consumo 
Descrição: 
Retorna uma lista com todos os registros de consumo. 
2.	[POST] Inserir Registro 
Endpoint: POST /api/consumo 
Descrição: 
Cria um novo registro de consumo. 

- Evidências

![image](https://github.com/user-attachments/assets/159531cf-1813-4f76-a0a4-3280c937d958)

![image](https://github.com/user-attachments/assets/891a5ebe-51e1-41be-ab6e-1781c0532d99)
