### Etherchannel
```sh
int range fa0/1-3 
switchport mode trunk
channel-group 1 mode active

int range fa0/1-3 
switchport mode trunk
channel-group 1 mode active
```

### Router-on-a-stick
```sh
vlan 10
name VLAN10
exit
vlan 20
name VLAN20
exit
vlan 99 
name management
exit
int vlan 99
ip add 192.168.99.2 255.255.255.0
no shut
exit
ip default-gateway 192.168.99.1
int range fa0/4-13
switchport mode access
switchport access vlan 10
int range fa0/14-24,g0/2
switchport mode access
switchport access vlan 20
int port-channel 1
switchport mode trunk
no shut
int g0/1
switchport mode trunk
no shut

vlan 10
name VLAN10
exit
vlan 20
name VLAN20
exit
vlan 99 
name management
exit
int vlan 99
ip add 192.168.99.3 255.255.255.0
no shut
exit
ip default-gateway 192.168.99.1
int range fa0/4-13,g0/1
switchport mode access
switchport access vlan 10
int range fa0/14-24,g0/2
switchport mode access
switchport access vlan 20
int port-channel 1
switchport mode trunk
no shut

int g0/0.10 
Description default-gateway for VLAN 10
encapsulation dot1Q 10
ip address 192.168.10.1 255.255.255.0
exit
int g0/0.20 
Description default-gateway for VLAN 20
encapsulation dot1Q 20
ip address 192.168.20.1 255.255.255.0
exit
int g0/0.99 
Description default-gateway for VLAN 99
encapsulation dot1Q 99
ip address 192.168.99.1 255.255.255.0
exit
int g0/0
Description Trunk link to s1
no shut
end
```

### DHCP
```sh
ip dhcp excluded-address 192.168.10.1 192.168.10.10
ip dhcp excluded-address 192.168.20.1 192.168.20.10

ip dhcp pool VLAN10-POOL
 network 192.168.10.0 255.255.255.0
 default-router 192.168.10.1
 dns-server 8.8.8.8

ip dhcp pool VLAN20-POOL
 network 192.168.20.0 255.255.255.0
 default-router 192.168.20.1
 dns-server 8.8.4.4
```
