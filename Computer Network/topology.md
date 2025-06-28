# Configure Single Area OSPFv2
## R1
```sh
conf t
hostname R1
interface g0/0
 ip address 192.168.12.1 255.255.255.0
 no shutdown

router ospf 1
 network 192.168.12.0 0.0.0.255 area 0
 network 192.168.1.0 0.0.0.255 area 0
 network 192.168.2.0 0.0.0.255 area 0
exit

int g0/1
 ip add 192.168.1.1 255.255.255.0
 no shut
int g0/2
 ip add 192.168.2.1 255.255.255.0
 no shut
```
## R2
```sh
conf t
hostname R2
interface g0/0
 ip address 192.168.12.2 255.255.255.0
 no shutdown
interface g0/1
 ip address 192.168.23.2 255.255.255.0
 no shutdown

router ospf 1
 network 192.168.12.0 0.0.0.255 area 0
 network 192.168.23.0 0.0.0.255 area 0
exit

```
## R3
```sh
conf t
hostname R3
interface g0/0
 ip address 192.168.23.3 255.255.255.0
 no shutdown

router ospf 1
 network 192.168.23.0 0.0.0.255 area 0
 network 192.168.3.0 0.0.0.255 area 0
 network 192.168.4.0 0.0.0.255 area 0
exit

int g0/1
 ip add 192.168.3.1 255.255.255.0
 no shut
int g0/2
 ip add 192.168.4.1 255.255.255.0
 no shut
```
