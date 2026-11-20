.class public final Lcom/redmadrobot/inputmask/model/state/FixedState;
.super Lcom/redmadrobot/inputmask/model/State;
.source "FixedState.kt"


# instance fields
.field private final ownCharacter:C


# direct methods
.method public constructor <init>(Lcom/redmadrobot/inputmask/model/State;C)V
    .locals 0

    .line 18
    invoke-direct {p0, p1}, Lcom/redmadrobot/inputmask/model/State;-><init>(Lcom/redmadrobot/inputmask/model/State;)V

    iput-char p2, p0, Lcom/redmadrobot/inputmask/model/state/FixedState;->ownCharacter:C

    return-void
.end method


# virtual methods
.method public accept(C)Lcom/redmadrobot/inputmask/model/Next;
    .locals 4

    .line 21
    iget-char v0, p0, Lcom/redmadrobot/inputmask/model/state/FixedState;->ownCharacter:C

    if-ne v0, p1, :cond_0

    .line 22
    new-instance v0, Lcom/redmadrobot/inputmask/model/Next;

    .line 23
    invoke-virtual {p0}, Lcom/redmadrobot/inputmask/model/State;->nextState()Lcom/redmadrobot/inputmask/model/State;

    move-result-object v1

    .line 24
    invoke-static {p1}, Ljava/lang/Character;->valueOf(C)Ljava/lang/Character;

    move-result-object v2

    const/4 v3, 0x1

    .line 26
    invoke-static {p1}, Ljava/lang/Character;->valueOf(C)Ljava/lang/Character;

    move-result-object p1

    .line 22
    invoke-direct {v0, v1, v2, v3, p1}, Lcom/redmadrobot/inputmask/model/Next;-><init>(Lcom/redmadrobot/inputmask/model/State;Ljava/lang/Character;ZLjava/lang/Character;)V

    return-object v0

    .line 29
    :cond_0
    new-instance p1, Lcom/redmadrobot/inputmask/model/Next;

    .line 30
    invoke-virtual {p0}, Lcom/redmadrobot/inputmask/model/State;->nextState()Lcom/redmadrobot/inputmask/model/State;

    move-result-object v0

    .line 31
    iget-char v1, p0, Lcom/redmadrobot/inputmask/model/state/FixedState;->ownCharacter:C

    invoke-static {v1}, Ljava/lang/Character;->valueOf(C)Ljava/lang/Character;

    move-result-object v1

    .line 33
    iget-char v2, p0, Lcom/redmadrobot/inputmask/model/state/FixedState;->ownCharacter:C

    invoke-static {v2}, Ljava/lang/Character;->valueOf(C)Ljava/lang/Character;

    move-result-object v2

    const/4 v3, 0x0

    .line 29
    invoke-direct {p1, v0, v1, v3, v2}, Lcom/redmadrobot/inputmask/model/Next;-><init>(Lcom/redmadrobot/inputmask/model/State;Ljava/lang/Character;ZLjava/lang/Character;)V

    return-object p1
.end method

.method public autocomplete()Lcom/redmadrobot/inputmask/model/Next;
    .locals 5

    .line 39
    new-instance v0, Lcom/redmadrobot/inputmask/model/Next;

    .line 40
    invoke-virtual {p0}, Lcom/redmadrobot/inputmask/model/State;->nextState()Lcom/redmadrobot/inputmask/model/State;

    move-result-object v1

    .line 41
    iget-char v2, p0, Lcom/redmadrobot/inputmask/model/state/FixedState;->ownCharacter:C

    invoke-static {v2}, Ljava/lang/Character;->valueOf(C)Ljava/lang/Character;

    move-result-object v2

    .line 43
    iget-char v3, p0, Lcom/redmadrobot/inputmask/model/state/FixedState;->ownCharacter:C

    invoke-static {v3}, Ljava/lang/Character;->valueOf(C)Ljava/lang/Character;

    move-result-object v3

    const/4 v4, 0x0

    .line 39
    invoke-direct {v0, v1, v2, v4, v3}, Lcom/redmadrobot/inputmask/model/Next;-><init>(Lcom/redmadrobot/inputmask/model/State;Ljava/lang/Character;ZLjava/lang/Character;)V

    return-object v0
.end method

.method public final getOwnCharacter()C
    .locals 1

    .line 18
    iget-char v0, p0, Lcom/redmadrobot/inputmask/model/state/FixedState;->ownCharacter:C

    return v0
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    .line 48
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "{"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-char v1, p0, Lcom/redmadrobot/inputmask/model/state/FixedState;->ownCharacter:C

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    const-string v1, "} -> "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p0}, Lcom/redmadrobot/inputmask/model/State;->getChild()Lcom/redmadrobot/inputmask/model/State;

    move-result-object v1

    if-nez v1, :cond_0

    const-string v1, "null"

    goto :goto_0

    :cond_0
    invoke-virtual {p0}, Lcom/redmadrobot/inputmask/model/State;->getChild()Lcom/redmadrobot/inputmask/model/State;

    move-result-object v1

    invoke-virtual {v1}, Lcom/redmadrobot/inputmask/model/State;->toString()Ljava/lang/String;

    move-result-object v1

    :goto_0
    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
