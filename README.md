# EmailServiceProvider
````
Generic class for mail serice with attchments.
````

## Settings in Web.config file

### 1. Add mails to specific directory
````
<system.net>  
    <mailSettings>  
      <smtp deliveryMethod="SpecifiedPickupDirectory">  
        <specifiedPickupDirectory  
          pickupDirectoryLocation="c:\maildrop" />  
      </smtp>  
    </mailSettings>  
  </system.net>  
````

### 2. SMTP server
````
<system.net>  
    <mailSettings>  
      <smtp deliveryMethod="Network">  
        <network  
          host="localhost"  
          port="25"  
          defaultCredentials="true"  
          password="******" 
          userName="username" />  
      </smtp>  
    </mailSettings>  
  </system.net>  
````