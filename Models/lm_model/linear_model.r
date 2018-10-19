data<-read.csv("p12_12.csv",header=TRUE)

#cor(data)
#plot(data)


train<-data[1:292,] 
test<-data[293:365,]


lm_model<-lm(DTRAD~ ., data=train)

lm_pred<-predict(lm_model, train[,-5])

lm_pred1<-predict(lm_model, test[,-5])


Results<-append(lm_pred,lm_pred1)
H=Results
A=20
r=15
PR=0.75
Energy = A * r * H * PR
results<-cbind(Results,Energy)

write.csv(results,"Results.csv",row.names=TRUE)
data<-read.csv("Results.csv")
names(data)<-c("Day_Number", "DTRAD","Energy")
write.csv(data,"Results.csv",row.names=FALSE)

