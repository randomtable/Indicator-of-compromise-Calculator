# Processo di analisi per raccolta Indicatori di Compromissione su Domini

Lo scopo di tale documento è descrivere il Processo di analisi per reperire, attraverso sistemi e dati pubblici, in maniera quanto più aperta e gratuita possibile, gli Indicatori necessari a identificare eventuali minacce sui propri sistemi.

Tale Processo è l'inizio di un percorso per rendere più semplice ed efficace l'identificazione dell'avversario, con il minor sforzo possibile.

Per tale motivo, è possibile che il Processo verrà cambiato nel corso del tempo, evoluto in una o più parti o totalmente riscritto.

E' bene quindi tenere presente che non esiste una "linea guida" che vada bene per tutto e che possa risolvere qualunque tipologia di caso, in quanto cambia il tipo di minaccia e il modo di affrontarla e/o analizzarla.

Utilizzare gli strumenti messi a disposizione da GitHub per segnalare migliorie, eventuali errori e suggerimenti.

Il Processo si dirama in tre situazioni distinte, che possono capitare nell'analisi:

- E' disponibile un sample.

- Non è disponibile un sample e si hanno evidenze di movimenti sospetti nella rete (ad esempio una mail di spam con mittente un account aziendale).

- Non è disponibile un sample e non si hanno evidenze di movimenti sospetti nella rete (ad esempio, nel caso di un controllo di routine).

Ogniuna di queste tre situazioni ha a sua volta due sotto-categorie:

- Se la rete non è visibile (ad esempio se l'analisi viene effettuata dall'esterno).

- Se la rete è visibile (si può operare sulla rete analizzata).

Di seguito si riporta il dettaglio di ogni situazione.

# E' disponibile un sample

Nel caso sia disponibile un sample ed abbiamo quindi una mail/file/altra evidenza di un oggetto malevolo, per prima cosa registrare l'evento (data-ora) e le informazioni sulla macchina (Indirizzo IP, Dominio, Indirizzo MAC e altri elementi distintivi).

Eseguire l'analisi del sample sulla piattaforma "any.run" (https://app.any.run/#register)

Una volta lanciata l'analisi sulla piattaforma, attendere che il malware venga detonato, e in caso aprirlo manualmente (la piattaforma permette di creare una sandbox, è possibile operare sui file malevoli in totale sicurezza).

Una volta analizzato il malware (o altra minaccia, potrebbe essere un link malevolo), nella scheda dei risultati, sulla destra, comparirà il pulsante "IOC".

Cliccare sul pulsante e copiare il contenuto negli appunti.

Una volta raccolti gli Indicatori, caricare il risultato copiato in precedenza sulla piattaforma "OTX" di AlienVault (https://otx.alienvault.com/pulse/create/new).

Caricati gli Indicatori su AlienVault, utilizzare "EndPoint Security", sempre dalla stessa piattaforma di AlienVault per lanciare una scansione rapida su tutti gli EndPoint partendo dal "pulse" appena creato (il quale è appunto una raccolta di Indicatori, raccolti sotto un unico "oggetto" chiamato "pulse", per eseguire una scansione specifica di una minaccia).

Dalle informazioni raccolte dalla scansione di "Any.run", si può inoltre cercare una soluzione di sicurezza specifica che possa debellare la minaccia.

Anche se le piattaforme sopracitate richiedono registrazione, il Processo non ha costi aggiuntivi (escludendo ovviamente le ore/uomo).

Avendo a disposizione degli Indicatori specifici, anche nel caso in cui non sia visibile la rete dell'Organizzazione in analisi, si possono inviare tali Indicatori al Responsabile IT per permettere al personale di implementare delle misure di controllo specifiche.

# Non è disponibile un sample e si hanno evidenze di movimenti sospetti nella rete

Nel caso in cui non fosse disponibile un sample, possiamo trovarci in due situazioni distinte:

- Non si ha visibilità della rete:

Nel caso in cui si effettui un'analisi dall'esterno, cercare sulla piattaforma "threatcrowd" (https://www.threatcrowd.org/) il dominio in analisi (ad esempio "google.com")

Una volta visualizzati i risultati, cliccare sulla seconda icona in alto a sinistra per visualizzare i risultati in formato tabellare.

Prendere in considerazione solo i Domini e gli Indirizzi IP.

Per ogni risultato, copiare il risultato e incollarlo sulla barra di ricerca della piattaforma VirusTotal.

- Si effettua un'analisi all'interno della rete.
