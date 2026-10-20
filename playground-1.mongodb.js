db.getName()
use("cityexplorer")
db.places.find().count()


db.places.find({tags:"park"})

db.places.find({tags:{$in:["park","running"]}})

db.places.find({tags:{$all:["park","running"]}})

db.places.find({"location.type":"Point"})

db.places.find({
    rating:{
        $gte:4,
        $lte:5
    },
    location:{
        $exists:true
    }

})


db.places.createIndex({
    location: "2dsphere"
})
db.places.find({
    location:{
        $near:{
            $geometry:{
                type:"Point",
                coordinates:[13.437,52.528]
            },
            $maxDistance: 3000
        }
    }
})