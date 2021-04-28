# Buy and Install a SSL Certificate with IIS
Buying a SSL certificate starts with creating a **Certificate Request**. Following illustration shows how to do it on a local IIS server:
![](/assets/ssl-certificate-request.png)

## Bit Length
In most cases it is necessary to set the bit length to 2048:
![](/assets/ssl-certificate-request-bit-length.png)

## Certificate Request Private Key Location
The Certificate Request is internally stored here:
(Note)
A certificate request can only be completed on the same computer where the certificate request has been created!
(Note)
Start > run > mmc > File > Add/Remove Snap-in... > Certificates > Computer account
![](/assets/ssl-certificate-request-location.png)

## Complete Certificate Request
Once recived the certificate from the certificate authority it's time to complete the request. This works only on the computer where the certificate request has been created!

Both file types (.cer) or (.crt) can be imported on IIS!
![](/assets/ssl-certificate-request-complete.png)

## Export (*.pxf) File
In order to install the certificate on an external web server the (*.pxf) file can be created like this:
![](/assets/ssl-certificate-export-pxf.png)
