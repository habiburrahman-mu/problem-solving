n = int(input())

bill_li = [100, 20, 10, 5, 1]
n_bills = 0

for bill in bill_li:
    div = n // bill
    n_bills += div
    if n%bill == 0:
        break
    n = n%bill
print(n_bills)

'''
125//100 = 1
1+
125%100 = 25

25//20 = 1
1+
25%20 = 5

5//5 = 0
+
5%5 = 0
'''