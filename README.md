# A simple Excel File to calculate Indicators of compromise

Used Platforms:
- VirusTotal
- Reverse.it

### Method used for manual calculation
- First of all, record the analyzed domain
- Record the VirusTotal URL of the "Relations" Tab for the analyzed Domain

If you see "Communicating Files" section under this Tab, and the files are malicious (10 or more findings), then click on the file
- Record the name of the file or the hash
- Record the URL of the file analysis result
- Record the "Last Submission" date, from the "Details" Tab
- Record the number of engines which have detected the file
- Record the total number of engines
- Calculate the "Malicious Rateo" (Number of engines which have detected the file / Total number of engines * 100)
- Go to the "Relations" Tab of the analyzed file, and go to "Contacted IP" section
- Record the IP and go to "reverse.it" site
- If you have an account, search the IP; if the IP have at least one file scored 100/100, then the IP is malicious
- Record the reverse.it URL of the IP analysis
Now, follow this procedure:
- Calculate the number of days from the analysis you are performing and Last Submission date
- Multiply the result by 10 (Result_Day)
- Calculate the following formula: 100 - Malicious Rateo (Malicious_Rate)
- If the Contacted IP IS NOT malicious, record 10 (Malicious_Plus)
- Now, solve this little formula: 100 - (Result_Day + Malicious_Rate + Malicious_Plus)
If the result of this method exceeds 50, then the finding is a possible Indicator of Compromise

Now you have the evidences and results "to indicate an indicator".
