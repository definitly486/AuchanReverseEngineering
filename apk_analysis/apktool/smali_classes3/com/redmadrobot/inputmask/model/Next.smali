.class public final Lcom/redmadrobot/inputmask/model/Next;
.super Ljava/lang/Object;
.source "Next.kt"


# instance fields
.field private final insert:Ljava/lang/Character;

.field private final pass:Z

.field private final state:Lcom/redmadrobot/inputmask/model/State;

.field private final value:Ljava/lang/Character;


# direct methods
.method public constructor <init>(Lcom/redmadrobot/inputmask/model/State;Ljava/lang/Character;ZLjava/lang/Character;)V
    .locals 1

    const-string v0, "state"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    .line 11
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/redmadrobot/inputmask/model/Next;->state:Lcom/redmadrobot/inputmask/model/State;

    iput-object p2, p0, Lcom/redmadrobot/inputmask/model/Next;->insert:Ljava/lang/Character;

    iput-boolean p3, p0, Lcom/redmadrobot/inputmask/model/Next;->pass:Z

    iput-object p4, p0, Lcom/redmadrobot/inputmask/model/Next;->value:Ljava/lang/Character;

    return-void
.end method


# virtual methods
.method public final getInsert()Ljava/lang/Character;
    .locals 1

    .line 11
    iget-object v0, p0, Lcom/redmadrobot/inputmask/model/Next;->insert:Ljava/lang/Character;

    return-object v0
.end method

.method public final getPass()Z
    .locals 1

    .line 11
    iget-boolean v0, p0, Lcom/redmadrobot/inputmask/model/Next;->pass:Z

    return v0
.end method

.method public final getState()Lcom/redmadrobot/inputmask/model/State;
    .locals 1

    .line 11
    iget-object v0, p0, Lcom/redmadrobot/inputmask/model/Next;->state:Lcom/redmadrobot/inputmask/model/State;

    return-object v0
.end method

.method public final getValue()Ljava/lang/Character;
    .locals 1

    .line 11
    iget-object v0, p0, Lcom/redmadrobot/inputmask/model/Next;->value:Ljava/lang/Character;

    return-object v0
.end method
