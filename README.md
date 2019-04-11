# EmailServiceProvider
````
Generic class for mail service with attachments.
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
          host="[host]"  
          port="[port]"  
          defaultCredentials="true"  
          password="[password]" 
          userName="[username]" />  
      </smtp>  
    </mailSettings>  
  </system.net>  
````
