export interface Player{
    id:number,
    playerName:string,
    coinsCollected:number,
    jumpsRemaining?:number,
    image?:string,
    isActive?:boolean
}