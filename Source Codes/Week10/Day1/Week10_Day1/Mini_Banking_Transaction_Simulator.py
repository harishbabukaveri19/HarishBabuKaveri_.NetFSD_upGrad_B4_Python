def deposit(balance, amount):
    if amount <= 0:
        print("Invalid amount! Deposit must be positive.")
        return balance
    balance += amount
    print("Balance updated:", balance)
    return balance

def withdraw(balance, amount):
    if amount <= 0:
        print("Invalid amount! Withdrawal must be positive.")
        return balance
    if amount > balance:
        print("Insufficient balance")
        return balance
    balance -= amount
    print("Balance updated:", balance)
    return balance
4
def check_balance(balance):
    print("Current Balance:", balance)

name = input("Enter your name: ")
balance = float(input("Enter initial balance: "))

print(f"\nWelcome, {name}!")

while True:
    print("\n1. Deposit")
    print("2. Withdraw")
    print("3. Check Balance")
    print("4. Exit")

    choice = input("Choose option: ")

    if choice == '1':
        amount = float(input("Enter amount to deposit: "))
        balance = deposit(balance, amount)

    elif choice == '2':
        amount = float(input("Enter amount to withdraw: "))
        balance = withdraw(balance, amount)

    elif choice == '3':
        check_balance(balance)

    elif choice == '4':
        print("Thank you for using the banking system!")
        break

    else:
        print("Invalid choice! Please select 1-4.")