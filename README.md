# Aflevering_2

## reason for ER diagram changes: 

- removed:
we removed an attribute called "GuestIdentifier" that was connected to the "guest" entity. 
Its purpose was to provide a failsafe to when the guest wasnt able to be contacted through the phone number. 
It focuses more on the buisness side of the perspective which we decided to cut away.

and Nicolajs ER-diagram

- added: 
"providerId" for the "Provider" entity was added due to having someting other than CVR as primary key. 
a group member mentioned that a buisness CVR can be changed from a company. and its an outside sort of ID. 
the ID added is a version that is local for the app and is individual.  

"ExperienceId" at the "discount" entity.
this was added since discount didnt have a way to link 

