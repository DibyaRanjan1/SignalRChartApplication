import { Injectable } from "@angular/core";
import { ChartModel } from "../model/chart-model";
import * as signalR from "@aspnet/signalr";

@Injectable({
  providedIn: "root",
})
export class SignalRService {
  public data: ChartModel[];
  public bradcastedData: ChartModel[];
  public textData: string;

  private hubConnection: signalR.HubConnection;
  constructor() {}

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder().configureLogging(signalR.LogLevel.Debug)
      .withUrl("http://localhost:64722/chart")
      .build();

    this.hubConnection
      .start()
      .then(() => console.log("Connection started"))
      .catch((err) => console.log("Error while starting connection: " + err));
  };

  public addTransferChartDataListener = () => {
    this.hubConnection.on("transferchartdata", (data) => {
      this.data = data;
    });
  };
 
  public addBroadcastChartDataListener = () => {
    this.hubConnection.on('broadcastchartdata', (data) => {
      this.bradcastedData = data;
    });
  }

  public broadcastChartData = () => {
    const datas = this.data.map(m => {
      const temp = {
        data: m.data,
        label: m.label
      }
      return temp;
    });
    
     this.hubConnection.invoke('broadcastchartdata', datas)
      .catch(err => console.log(err));
  }

 public textChangeListner() {
   this.hubConnection.on('broadcasttextdata',(text) =>{
  this.textData = text;
   });
 }

 public textBroadCaster( name) {
   this.hubConnection.invoke('broadcasttextdata', name)
   .catch(err => console.log(err));
 }

}
