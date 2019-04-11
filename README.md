# EmailServiceProvider
````
Generic class for mail service with attachments.
Examples avaialable for Asp.Net and Core
````

## For Asp.Net, web.config file

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
## For Core, appsetting.json file

### 3. SMTP server configuration
````
"Smtp": {
    "DeliveryMethod": "SpecifiedPickupDirectory",
    "PickupDirectoryLocation": "c:\\maildrop"
  }  
````
