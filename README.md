# TLSConfig

This simple tool is intended for disabling TLS 1.0 and TLS 1.1 in Windows platforms.

Best practices outlined in [RFC-7525](https://tools.ietf.org/html/rfc7525) give reasons why it is discouraged to use protocol TLS 1.0 and TLS 1.1. PCI-DSS recommends users to switch from protocol TLS 1.0 and adopt protocol TLS 1.2+.

Following table shows for each browser the percentage of connections made to SSL/TLS servers using protocol TLS 1.0 and TLS 1.1:

Browser/Client Name    | Percentage (%) - Both TLS 1.1 and TLS 1.0
-----------------------|-----------------------------------------
Microsoft IE and Edge  |  0.72%
Mozilla Firefox        |  1.2%
Safari/Webkit          |  0.36%
Google Chrome          |  0.5%
SSL Pulse November 2018|  5.84%

(Source: [Qualys Blog](https://blog.qualys.com/ssllabs/2018/11/19/grade-change-for-tls-1-0-and-tls-1-1-protocols))

This tool was implemented for use in Windows platforms as instructed in:
- https://docs.microsoft.com/en-us/windows-server/security/tls/tls-registry-settings

Applies to: Windows Server (Semi-Annual Channel), Windows Server 2019, Windows Server 2016, Windows 10

## Usage

You can clone this repository, review its code and build the console app yourself. I'm also providing an executable file for [download](https://github.com/TCGV/TLSConfig/raw/master/Release/Tcgv.TLSConfig.exe).

The console app interface is pretty straightforward, just follow through its commands to evaluate and disable TLS protocol versions:

![image](https://github.com/TCGV/TLSConfig/blob/master/Release/tlsconfig.png)

⚠️ <b>ATTENTION</b> ⚠️ Before disabling protocols TLS 1.0 and TLS 1.1 in a remote Virtual Machine make sure this won't lock you out of it, for instance by ensuring TLS 1.2 is supported and enabled for connecting through Remote Desktop Protocol (RDP).

## Licensing

This code is released under the MIT License:

Copyright (c) TCGV.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
