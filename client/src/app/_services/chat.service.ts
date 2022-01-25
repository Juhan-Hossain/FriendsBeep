import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { MessageDto } from '../_models/MessageDto';

@Injectable({
  providedIn: 'root',
})
export class ChatService {
  // private  connection: any = new signalR.HubConnectionBuilder().withUrl("https://localhost:44379/chatsocket")
  // .configureLogging(signalr.LogLevel.Information)
  // .build();
  readonly POST_URL = 'https://localhost:44379/api/chat/send';

  private receivedMessageObject: MessageDto = new MessageDto();
  private sharedObj = new Subject<MessageDto>();

  constructor() {}
}
