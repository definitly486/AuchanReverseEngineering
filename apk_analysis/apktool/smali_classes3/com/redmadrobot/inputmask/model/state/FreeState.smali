.class public final Lcom/redmadrobot/inputmask/model/state/FreeState;
.super Lcom/redmadrobot/inputmask/model/State;
.source "FreeState.kt"


# instance fields
.field private final ownCharacter:C


# direct methods
.method public constructor <init>(Lcom/redmadrobot/inputmask/model/State;C)V
    .locals 1

    const-string v0, "child"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    .line 19
    invoke-direct {p0, p1}, Lcom/redmadrobot/inputmask/model/State;-><init>(Lcom/redmadrobot/inputmask/model/State;)V

    iput-char p2, p0, Lcom/redmadrobot/inputmask/model/state/FreeState;->ownCharacter:C

    return-void
.end method


# virtual methods
.method public accept(C)Lcom/redmadrobot/inputmask/model/Next;
    .locals 4

    .line 22
    iget-char v0, p0, Lcom/redmadrobot/inputmask/model/state/FreeState;->ownCharacter:C

    const/4 v1, 0x0

    if-ne v0, p1, :cond_0

    .line 23
    new-instance v0, Lcom/redmadrobot/inputmask/model/Next;

    .line 24
    invoke-virtual {p0}, Lcom/redmadrobot/inputmask/model/State;->nextState()Lcom/redmadrobot/inputmask/model/State;

    move-result-object v2

    .line 25
    invoke-static {p1}, Ljava/lang/Character;->valueOf(C)Ljava/lang/Character;

    move-result-object p1

    const/4 v3, 0x1

    .line 23
    invoke-direct {v0, v2, p1, v3, v1}, Lcom/redmadrobot/inputmask/model/Next;-><init>(Lcom/redmadrobot/inputmask/model/State;Ljava/lang/Character;ZLjava/lang/Character;)V

    return-object v0

    .line 30
    :cond_0
    new-instance p1, Lcom/redmadrobot/inputmask/model/Next;

    .line 31
    invoke-virtual {p0}, Lcom/redmadrobot/inputmask/model/State;->nextState()Lcom/redmadrobot/inputmask/model/State;

    move-result-object v0

    .line 32
    iget-char v2, p0, Lcom/redmadrobot/inputmask/model/state/FreeState;->ownCharacter:C

    invoke-static {v2}, Ljava/lang/Character;->valueOf(C)Ljava/lang/Character;

    move-result-object v2

    const/4 v3, 0x0

    .line 30
    invoke-direct {p1, v0, v2, v3, v1}, Lcom/redmadrobot/inputmask/model/Next;-><init>(Lcom/redmadrobot/inputmask/model/State;Ljava/lang/Character;ZLjava/lang/Character;)V

    return-object p1
.end method

.method public autocomplete()Lcom/redmadrobot/inputmask/model/Next;
    .locals 5

    .line 40
    new-instance v0, Lcom/redmadrobot/inputmask/model/Next;

    .line 41
    invoke-virtual {p0}, Lcom/redmadrobot/inputmask/model/State;->nextState()Lcom/redmadrobot/inputmask/model/State;

    move-result-object v1

    .line 42
    iget-char v2, p0, Lcom/redmadrobot/inputmask/model/state/FreeState;->ownCharacter:C

    invoke-static {v2}, Ljava/lang/Character;->valueOf(C)Ljava/lang/Character;

    move-result-object v2

    const/4 v3, 0x0

    const/4 v4, 0x0

    .line 40
    invoke-direct {v0, v1, v2, v3, v4}, Lcom/redmadrobot/inputmask/model/Next;-><init>(Lcom/redmadrobot/inputmask/model/State;Ljava/lang/Character;ZLjava/lang/Character;)V

    return-object v0
.end method

.method public final getOwnCharacter()C
    .locals 1

    .line 19
    iget-char v0, p0, Lcom/redmadrobot/inputmask/model/state/FreeState;->ownCharacter:C

    return v0
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    .line 49
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, ""

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-char v1, p0, Lcom/redmadrobot/inputmask/model/state/FreeState;->ownCharacter:C

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    const-string v1, " -> "

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
