.class public final Lcom/redmadrobot/inputmask/helper/RTLCaretStringIterator;
.super Lcom/redmadrobot/inputmask/helper/CaretStringIterator;
.source "RTLCaretStringIterator.kt"


# direct methods
.method public constructor <init>(Lcom/redmadrobot/inputmask/model/CaretString;)V
    .locals 3

    const-string v0, "caretString"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const/4 v0, 0x2

    const/4 v1, 0x0

    const/4 v2, 0x0

    .line 5
    invoke-direct {p0, p1, v2, v0, v1}, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;-><init>(Lcom/redmadrobot/inputmask/model/CaretString;IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-void
.end method


# virtual methods
.method public insertionAffectsCaret()Z
    .locals 2

    .line 7
    invoke-virtual {p0}, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;->getCurrentIndex()I

    move-result v0

    invoke-virtual {p0}, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;->getCaretString()Lcom/redmadrobot/inputmask/model/CaretString;

    move-result-object v1

    invoke-virtual {v1}, Lcom/redmadrobot/inputmask/model/CaretString;->getCaretPosition()I

    move-result v1

    if-gt v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method
