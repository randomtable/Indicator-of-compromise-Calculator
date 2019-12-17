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

Ognuna di queste tre situazioni ha a sua volta due sotto-categorie:

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

Nel caso in cui non fosse disponibile un sample, ma fossero disponibili evidenze di movimenti sospetti (ad esempio, una mail di spam il cui mittente è un indirizzo legittimo), possiamo trovarci in due situazioni distinte:

### Non si ha visibilità della rete:

Nel caso in cui si effettui un'analisi dall'esterno, cercare sulla piattaforma "threatcrowd" (https://www.threatcrowd.org/) il dominio in analisi (ad esempio "google.com")

Una volta visualizzati i risultati, cliccare sulla seconda icona in alto a sinistra per visualizzare i risultati in formato tabellare.

Prendere in considerazione solo i Domini e gli Indirizzi IP.

Per ogni risultato, copiare il risultato e incollarlo sulla barra di ricerca della piattaforma VirusTotal.

Sulla piattaforma VirusTotal, cliccare su "Relations" e verificare che esistano "Communicating Files".

Nel caso in cui esistano, per ogni file, si segue la seguente procedura:

- Cliccare sul file per aprirne i dettagli.

- Cliccare su "Relations".

- Espandere tutti i "Contacted IPs" e salvarli.

- Espandere tutti i "Contacted Domains" e salvarli.

- Cliccare su "Behavior".

- Salvare il risultato dalla sezione "File System Actions" fino a fine pagina.

Effettuata questa operazione per ogni file, passare al prossimo risultato evidenziato dalla piattaforma ThreatCrowd.

Una volta raccolti gli Indicatori, caricare il risultato copiato in precedenza sulla piattaforma "OTX" di AlienVault (https://otx.alienvault.com/pulse/create/new).

Caricati gli Indicatori su AlienVault, utilizzare "EndPoint Security", sempre dalla stessa piattaforma di AlienVault per lanciare una scansione rapida su tutti gli EndPoint partendo dal "pulse" appena creato (il quale è appunto una raccolta di Indicatori, raccolti sotto un unico "oggetto" chiamato "pulse", per eseguire una scansione specifica di una minaccia).

Questo permette di avvertire il personale dell'Organizzazione, trasmettendo tutta l'analisi al Responsabile Tecnico.

Il Responsabile Tecnico dovrà provvedere a sua volta ad implementare i controlli specifici per gli Indicatori.

E' consigliabile, da parte del Responsabile Tecnico interno all'Organizzazione, l'invio all'analista (se ovviamente è possibile) di dati aggiuntivi atti ad approfondire meglio l'analisi (come ad esempio l'indirizzo IP pubblico della rete interna) in quanto molte Organizzazioni hanno i propri applicativi web su server esterni o hosting provider.

### Si effettua un'analisi all'interno della rete.

Nel caso in cui si possa effettuare un'analisi anche all'interno della rete, procedere con l'individuazione degli asset e definire i punti di ingresso nella rete.

Ciò permette di mappare i server e i client interni e quali relazioni hanno con l'esterno.

Si può a questo punto effettuare la verifica dei log, in base ad una lista di indicatori comuni o seguendo le procedure già implementate nell'organizzazione. (un esempio di indicatori comuni può essere questo, sempre dalla piattaforma "AlienVault OTX": https://otx.alienvault.com/pulse/5df899489e018150c375646e)

Una volta raccolte tutte le informazioni relative alla rete interna e alla rete esterna (in caso di hosting esterni), seguire la seguente procedura:

Cercare sulla piattaforma "threatcrowd" (https://www.threatcrowd.org/) gli indirizzi IP, i Domini e relativi Sottodomini relativi all'Organizzazione in analisi.

Una volta visualizzati i risultati, cliccare sulla seconda icona in alto a sinistra per visualizzare i risultati in formato tabellare.

Prendere in considerazione solo i Domini e gli Indirizzi IP.

Per ogni risultato, copiare il risultato e incollarlo sulla barra di ricerca della piattaforma VirusTotal.

Sulla piattaforma VirusTotal, cliccare su "Relations" e verificare che esistano "Communicating Files".

Nel caso in cui esistano, per ogni file, si segue la seguente procedura:

- Cliccare sul file per aprirne i dettagli.

- Cliccare su "Relations".

- Espandere tutti i "Contacted IPs" e salvarli.

- Espandere tutti i "Contacted Domains" e salvarli.

- Cliccare su "Behavior".

- Salvare il risultato dalla sezione "File System Actions" fino a fine pagina.

Effettuata questa operazione per ogni file, passare al prossimo risultato evidenziato dalla piattaforma ThreatCrowd.

Una volta raccolti gli Indicatori, caricare il risultato copiato in precedenza sulla piattaforma "OTX" di AlienVault (https://otx.alienvault.com/pulse/create/new).

Caricati gli Indicatori su AlienVault, utilizzare "EndPoint Security", sempre dalla stessa piattaforma di AlienVault per lanciare una scansione rapida su tutti gli EndPoint partendo dal "pulse" appena creato (il quale è appunto una raccolta di Indicatori, raccolti sotto un unico "oggetto" chiamato "pulse", per eseguire una scansione specifica di una minaccia).

Potendo operare all'interno della rete, è possibile effettuare degli interventi specifici sugli asset, concordandoli con il Responsabile Tecnico.

# Non è disponibile un sample e non si hanno evidenze di movimenti sospetti nella rete

Nel caso in cui non fosse disponibile un sample e non ci sia nessuna evidenza di movimenti sospetti nella rete (ad esempio un controllo di routine), possiamo trovarci in due situazioni distinte:

### Non si ha visibilità della rete:

Nel caso in cui si effettui un'analisi dall'esterno, cercare sulla piattaforma "threatcrowd" (https://www.threatcrowd.org/) il dominio in analisi (ad esempio "google.com")

Una volta visualizzati i risultati, cliccare sulla seconda icona in alto a sinistra per visualizzare i risultati in formato tabellare.

Prendere in considerazione solo i Domini e gli Indirizzi IP.

Per ogni risultato, copiare il risultato e incollarlo sulla barra di ricerca della piattaforma VirusTotal.

Sulla piattaforma VirusTotal, cliccare su "Relations" e verificare che esistano "Communicating Files".

Nel caso in cui esistano, prendere in considerazione solo i file i quali hanno come data il mese e l'anno corrente e, per ogni file, si segue la seguente procedura:

- Cliccare sul file per aprirne i dettagli.

- Cliccare su "Relations".

- Espandere tutti i "Contacted IPs" e salvarli.

- Espandere tutti i "Contacted Domains" e salvarli.

- Cliccare su "Behavior".

- Salvare il risultato dalla sezione "File System Actions" fino a fine pagina.

Effettuata questa operazione per ogni file preso in considerazione, passare al prossimo risultato evidenziato dalla piattaforma ThreatCrowd.

Una volta raccolti gli Indicatori, caricare il risultato copiato in precedenza sulla piattaforma "OTX" di AlienVault (https://otx.alienvault.com/pulse/create/new).

Caricati gli Indicatori su AlienVault, utilizzare "EndPoint Security", sempre dalla stessa piattaforma di AlienVault per lanciare una scansione rapida su tutti gli EndPoint partendo dal "pulse" appena creato (il quale è appunto una raccolta di Indicatori, raccolti sotto un unico "oggetto" chiamato "pulse", per eseguire una scansione specifica di una minaccia).

Questo permette di avvertire il personale dell'Organizzazione, trasmettendo tutta l'analisi al Responsabile Tecnico.

Il Responsabile Tecnico dovrà provvedere a sua volta ad implementare i controlli specifici per gli Indicatori.

E' consigliabile, da parte del Responsabile Tecnico interno all'Organizzazione, l'invio all'analista (se ovviamente è possibile) di dati aggiuntivi atti ad approfondire meglio l'analisi (come ad esempio l'indirizzo IP pubblico della rete interna) in quanto molte Organizzazioni hanno i propri applicativi web su server esterni o hosting provider.

### Si effettua un'analisi all'interno della rete.

Nel caso in cui si possa effettuare un'analisi anche all'interno della rete, procedere con l'individuazione degli asset e definire i punti di ingresso nella rete.

Ciò permette di mappare i server e i client interni e quali relazioni hanno con l'esterno.

Si può a questo punto effettuare la verifica dei log, in base ad una lista di indicatori comuni o seguendo le procedure già implementate nell'organizzazione. (un esempio di indicatori comuni può essere questo, sempre dalla piattaforma "AlienVault OTX": https://otx.alienvault.com/pulse/5df899489e018150c375646e)

Una volta raccolte tutte le informazioni relative alla rete interna e alla rete esterna (in caso di hosting esterni), seguire la seguente procedura:

Cercare sulla piattaforma "threatcrowd" (https://www.threatcrowd.org/) gli indirizzi IP, i Domini e relativi Sottodomini relativi all'Organizzazione in analisi.

Una volta visualizzati i risultati, cliccare sulla seconda icona in alto a sinistra per visualizzare i risultati in formato tabellare.

Prendere in considerazione solo i Domini e gli Indirizzi IP.

Per ogni risultato, copiare il risultato e incollarlo sulla barra di ricerca della piattaforma VirusTotal.

Sulla piattaforma VirusTotal, cliccare su "Relations" e verificare che esistano "Communicating Files".

Nel caso in cui esistano, prendere in considerazione solo i file i quali hanno come data il mese e l'anno corrente e, per ogni file, si segue la seguente procedura:

- Cliccare sul file per aprirne i dettagli.

- Cliccare su "Relations".

- Espandere tutti i "Contacted IPs" e salvarli.

- Espandere tutti i "Contacted Domains" e salvarli.

- Cliccare su "Behavior".

- Salvare il risultato dalla sezione "File System Actions" fino a fine pagina.

Effettuata questa operazione per ogni file preso in considerazione, passare al prossimo risultato evidenziato dalla piattaforma ThreatCrowd.

Una volta raccolti gli Indicatori, caricare il risultato copiato in precedenza sulla piattaforma "OTX" di AlienVault (https://otx.alienvault.com/pulse/create/new).

Caricati gli Indicatori su AlienVault, utilizzare "EndPoint Security", sempre dalla stessa piattaforma di AlienVault per lanciare una scansione rapida su tutti gli EndPoint partendo dal "pulse" appena creato (il quale è appunto una raccolta di Indicatori, raccolti sotto un unico "oggetto" chiamato "pulse", per eseguire una scansione specifica di una minaccia).

Potendo operare all'interno della rete, è possibile effettuare degli interventi specifici sugli asset, concordandoli con il Responsabile Tecnico.

# Considerazioni finali

Questo Processo, per quanto semplice possa risultare, permette di raccogliere le evidenze e gli indicatori necessari per analizzare le proprie reti e i propri sistemi in qualunque tipo di situazione e in maniera del tutto trasparente e gratuita (escludendo le ore/uomo).

Questo è solo l'inizio di un percorso per portare una semplificazione sempre maggiore a fronte di un mondo sempre più complesso e connesso.
