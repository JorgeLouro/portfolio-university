#include <stdio.h>
#include <string.h>
#include <locale.h>

#define SIZE 10

// Estrutura para guardar a informação de um aluno
struct aluno {
	int numero;
	char nome[80];
};

typedef struct aluno ALUNO;

// Recolher um valor inteiro
int RecolhaInt(const char* mensagem) {
	printf("\n%s",mensagem);
	int x;
	scanf("%i",&x);
	//Limpar o buffer
	getc(stdin);
	return x;
}

// Mostrar os dados de um aluno
void ShowAluno(ALUNO aluno) {
	printf("Numero: %i\nNome: %s\n\n",aluno.numero,aluno.nome);
	return;
}

// Inserir um aluno
void AddAluno(ALUNO* aluno, int* i){
	// aluno é o apontador para o vetor de alunos
	//i é o apontador para o último elemento inserido no vetor
	//
	//para obter o valor a que o apontador i se refere utilizaza-se
	//a *dereferenciação* na forma (*i),
	//que significa "o valor inteiro que está no endereço i"
	//
	//Verifica se o vetor ainda tem slots disponíveis
	if ((*i) == SIZE) {
		printf("Número máximo de alunos atingido!!\n\n");
		return;
	}
	//Como não estamos no último elemento podemos incrementar o número
	//do último elemento e inseri-lo
	(*i)++;
	//Recolha do número do novo aluno
	aluno[(*i)].numero=RecolhaInt("Escreva o número do novo aluno: ");
	//Recolha do nome do novo aluno
	printf("Escreva o nome do novo aluno: ");
	scanf("%s",aluno[(*i)].nome);
	getc(stdin);

	printf("Aluno inserido!\n");
	return;
}

// Apagar um aluno
void DelAluno(ALUNO* aluno, int* i, int* n){
	//Vamos copiar todos os elementos seguintes do vetor ao elemento a apagar
	//para o elemento anterior e, no final, reduzir o número de elementos
	//do vetor em uma unidade.
	//n é o apontador para o número do vetor a apagar e
	//i é o apontador para o número de elementos do vetor
	//aluno é o apontador para o vetor de dados
	
	int j;  //variável auxiliar para ir de "n" a "i"
	//percorrer o vetor a começar no elemento "(*n)" até ao penúltimo (j <(*i)
	//vamos, em cada volta do ciclo, copiar o elemento j+1 para o elemento j
	for(j=(*n); j<(*i); j++){
		//Copiar o nome seguinte para a posição corrente
		strcpy(aluno[j].nome, aluno[j+1].nome);
		//copiar o número seguinte para a posição corrente
		aluno[j].numero = aluno[j+1].numero;
	}
	//dimunuir o número de elementos do vetor em uma unidade
	//dado que i é um apontador para um inteiro, (*i) representa
	//"o valor inteiro que esta´no endereço i"
	(*i)--;
	//dado que podemos estar a eliminar o último elemento, o valor de (*n)
	//nunca pode ser superior ao de (*i), pois neste caso estaria 
	//a apontar para um elemento não existente.
	//Neste caso, se o valor for superior terá de ser tornado igual
	//Mesmo no caso de supressão do último elemento em que (*i)
	//irá ter o valor de -1, (*n) terá forçosamente de ser igual
	if ((*n)>(*i)) (*n)=(*i);
	//Mostrar os dados do aluno corrente, se este existir
	if ((*n)>=0)
		ShowAluno(aluno[(*n)]);
	return;
}

// Alterar um aluno
void ModAluno(ALUNO* aluno, int n) {
	//aluno é o apontador para o vetor de alunos
	//Neste caso, dado que não há alteração nem do número do elemento corrente
	//nem do número de elementos do vetor, o elemento corrente (n)
	//é passado por valor e não por referência (apontador)
	
	//recolher o novo número de aluno
	aluno[n].numero=RecolhaInt("Escreva o novo número do aluno: ");
	
	//recolher o novo nome do aluno
	printf("Escreva o novo nome do aluno: ");
	scanf("%s",aluno[n].nome);
	getc(stdin);

	printf("Aluno alterado!\n");
	return;
}

// Importar de ficheiro
void Import(ALUNO* aluno, int* i, int* n){
	//Ler os dados de alunos num ficheiro de texto com o formato
	//<numéro> <nome>
	//em cada linha.
	//Os valores de i e de n são passados por referência (apontadores)
	//dado que o vetor irá ser inicializado com os dados do ficheiro
	//perdendo-se tudo o que no vetor poderia existir
	
	int li = -1; //variável auxiliar para contar linhas lidas no ficheiro
	
	//variáveis auxiliares para leitaura do ficheiro
	int num;
	char nom[80];

	//abrir o ficheiro contendo os dados para leitura ("r")
	FILE* f = fopen("alunos.txt","r");
	//verificar se a operação de abertura foi efetuada com sucesso,
	//caso contrário abandonar a rotina sem alterações ao vator
	if (f != NULL) {
		//Inicializar os valores de (*i) e de (*n) para "vetor vazio" (ambos a -1)
		(*i)=-1;
		(*n)=-1;
	
		//Ler as linhas do ficheiro, no formato especificado até ao fim do ficheiro (EOF),
		//ou até ao número limite de dados (SIZE)
		while((fscanf(f,"%i %s\n",&num,nom) != EOF) && (li < SIZE)) {
			//incrementar o número de linhas [alunos] lidos
			li++;
			//Copiar o número lido para o elemento li do vetor
			aluno[li].numero = num;
			//Copiar o nome lido para o elemento li do vetor
			strcpy(aluno[li].nome,nom);
		}
		//atribuir à dimensão do vetor o número de linhas lidas
		(*i)=li;
		//Se houver linhas lidas, atribuir 0 (zero) ao elemento corrente e mostrar
		//os respetivos dados
		if (li>=0) {
			(*n)=0;
			//dado que (*n) é 0, podemos obviar e mostrar aluno[0] em vez
			//de aluno[(*n)], (que é a mesma coisa), mas sem o tempo da operação
			//de dereferenciação
			ShowAluno(aluno[0]);
		}
		//**IMPORTANTE**
		//Fechar o ficheiro aberto para obter os dados
		fclose(f);
	} else
		printf("Erro ao abrir o ficheiro\n");
	return;
}

// Exportar para ficheiro
void Export(ALUNO* aluno, int i) {
	//Gravar os dados de todos os alunos do vetor com o formato
	//<numero> <nome>
	//em cada linha
	//Dado que apenas vamos gravar os dados em ficheiro e não vai ser alterada
	//nem a posição corrente, nem o número de elementos do vetor,
	//a dimensão do vetor é passada por valor e não por referência (apontador)
	
	int n; //variável auxiliar para precorrer o vetor
	//abrir o ficheiro para escrita. Se o ficheiro existir é apagado e criado um novo, vazio ("w")
	FILE* f = fopen("alunos.txt","w");
	//verificar se a operação de abertura foi efetuada com sucesso,
	if (f != NULL) {
		//percorrer o vetor desde o elemento 0 até ao elemento i (inclusivé)
		//e gravar cada aluno numa linha
		for (n=0; n<=i; n++)
			//escrever o aluno n no ficheiro
			fprintf(f,"%i %s\n",aluno[n].numero,aluno[n].nome);
		fclose(f);
	} else
		printf("Erro na criação do ficheiro\n");
	return;
}

int main() {
	setlocale(LC_ALL,"Portuguese");
	//vetor a tratar
	ALUNO alunos[SIZE];
	//indicador de localização do vetor
	int i = -1; //dimensão de elementos válidos no vetor
	int n = -1; //elemento corrente do vetor
	
	int op=0;  //seletor de opções
	char fim = 'n'; //indicação de fim de execução

	//ciclo principal de opções
	//*NOTA*
	//Dada a natureza dos testes feitos nas opções, a primeira opção válida só poderá ser
	//ou adicionar elementos, ler de ficheiro ou terminar o programa
	do { 
		//mostrar menu de opções
		printf("0 - Sair\n");
		printf("1 - Inserir Aluno\n");
		printf("2 - Alterar Aluno\n");
		printf("3 - Apagar Aluno\n");
		printf("4 - Ir para o primeiro\n");
		printf("5 - Ir para o anterior\n");
		printf("6 - Ir para o seguinte\n");
		printf("7 - Ir para o último\n");
		printf("8 - Exportar alunos para ficheiro\n");
		printf("9 - Importar alunos de ficheiro\n");
		//recolher opção
		op = RecolhaInt("Digite uma opção: ");
		// de acordo com a opção efetuar uma das operações
		// descritas acima
		switch (op) {
			case 0: //fim do programa
				//assinala o fim
				fim='s';
				//Termina o switch
				break;
			case 1: //Inserir um aluno
				//Evoca a adição de alunos passando por referência
				//o vetor e o número de elementos válidos
				AddAluno(alunos, &i);
				//atribui ao número do elemento corrente 
				//o número do elemento inserido
				n=i;
				//Termina o switch
				break;
			case 2: //Modificar o elemento n
				//se o vetor tiver alunos
				if (i>=0)
					//evoca a rotina de modificação do aluno corrente
					ModAluno(alunos, n);
				else
					printf("Não há alunos inseridos\n");
				//Termina o switch
				break;
			case 3: //Apagar o elemento n
				//se o vetor tiver alunos
				if (i>=0)
					//evoca a rotina de eliminação de um elemento
					DelAluno(alunos, &i, &n);
				else
					printf("Não há alunos inseridos\n");
				break;
			case 4: //ir para o primeiro elemento
				//se o vetor tiver alunos
				if (i>=0) {
					//atribuir 0 ao valor corrente e mostrar os dados do aluno
					n=0;
					ShowAluno(alunos[n]);
				} else {
					printf("Não há alunos inseridos\n");
				}
				break;
			case 5://ir para o elemento anterior
				//se o vetor tiver alunos
				if (i>=0){
					//e se não estou no primeiro
					if (n>0){
						//diminuir o número corrente numa unidade e mostrar os dados do aluno
						n--;
						ShowAluno(alunos[n]);
					} else {
						printf("Não pode passar para trás do primeiro\n");
					} 
				} else {
					printf("Não há alunos inseridos\n");
				}
				//Termina o switch
				break;
			case 6: //ir para o elemento seguinte
				//se o vetor tiver elementos
				if  (i>=0){
					//e se não estou no último (n = i)
					if (n<i){
						//aumentar o número corrente numa unidade e mostrar os dados do aluno
						n++;
						ShowAluno(alunos[n]);
					} else {
							printf("Não pode passar para a frente do último\n");
					}
				} else {
					printf("Não há alunos inseridos\n");
				}
				//Terminar o switch
				break;
			case 7: //ir para o último
				//se o vetor tiver alunos
				if (i>=0) {
					//atribuir a n o número de elementos válidos do vetor e mostrar os dados do aluno
					n=i;
					ShowAluno(alunos[n]);
				} else {
					printf("Não há alunos inseridos\n");
				}
				//Terminar o switch
				break;
			case 8: //Exportar para ficheiro
				//Se o vetor tiver alunos
				if (i>=0)
					//evocar a rotina de exportação para ficheiro
					Export(alunos, i);
				else
					printf("Não há alunos inseridos\n");
				//Terminar o switch
				break;
			case 9: //Importar de ficheiro
				//Evocar a rotina de importação dos dados de alunos a partir de ficheiro
				//NOTA: os valores de i e de n irão ser atualizados em função do número
				//de elementos lidos do ficheiro
				Import(alunos, &i, &n);
				//Terminar o switch
				break;
			default:
				//Indicação de opção errada
				printf("Escolha uma opção do menu\n");
				//Terminar o switch
				break;
		}
	} while (fim == 'n'); //Repetir o ciclo enquanto a variável fim contiver o valor "n"
	
	//fim do programa com indicação de sucesso no retorno ao sistema de exploração
	return 0;
}
