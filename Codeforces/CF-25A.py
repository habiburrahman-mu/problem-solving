n = int(input())
inp = list(map(int, input().split()))
ev, ev_ind, odd, odd_ind = [0, 0, 0, 0]
for i in range(n):
	if inp[i]%2==0:
		ev+=1
		ev_ind = i
	else:
		odd+=1
		odd_ind = i

if ev==1:
	print(ev_ind+1)
else:
	print(odd_ind+1)