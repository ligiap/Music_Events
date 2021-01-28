select e.EventDate, e.EventName, b.ArtistID, a.StageName
from Event e
	join Booking b on b.EventID = e.ID
	join Artist a on a.ID = b.ArtistID
order by e.EventDate desc,
	e.EventName asc,
	a.StageName asc

select e.EventDate, e.EventName, count(b.ArtistID), sum(b.Payment)
from Event e
	join Booking b on b.EventID = e.ID
	join Artist a on a.ID = b.ArtistID
group by e.EventDate, e.EventName
order by e.EventDate desc,
	e.EventName asc