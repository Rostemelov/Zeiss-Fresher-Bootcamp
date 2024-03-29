# zeiss-bootcamp-2024
## User Story 1:

Customer Theory

Financial Risk System
             A global investment bank based in India, New York and Singapore trades (buys and sells) financial products with other banks (“counterparties"). When share prices on the stock markets move up or down, the bank either makes money or loses it. At the end of the working day, the bank needs to gain a view of how much risk of losing money they are exposed to, by running some calculations on the data held about their trades. The bank has an existing Trade Data System (TDS) and Reference Data System (RDS) but needs a new Risk System.

Trade Data System (TDS)
The Trade Data System maintains a store of all trades made by the bank. It is already configured to generate a file-based XML export on a network share of trade data at the close of business (5pm) in NewYork. The export includes the following information for every trade made by the bank: 
• Trade ID, Date, Current trade value in US dollars, Counterparty ID
Reference Data System (RDS)
The Reference Data System maintains all of the reference data needed by the bank. This includes
Information about counterparties; each of which represents an individual, a bank, etc. A file-based XML
Export is also available on a network share and includes basic information about each counterparty. A new organization-wide reference data system is due for completion in the next 3 months, with the current system eventually being decommissioned

The high-level requirements for the new Risk System are as follows.
 Import trade data from the Trade Data System and Import counterparty data from the Reference Data System. Join the two sets of data together, enriching the trade data with information about the Counterparty, for each counterparty, calculate the risk that the bank is exposed to.  Generate a report that can be imported into Microsoft Excel containing the risk figures for all counterparties known by the bank.
 Distribute the report to the business users before the start of the next trading day (9am) in
Singapore. Provide a way for a subset of the business users to configure and maintain the external parameters used by the risk calculations.


