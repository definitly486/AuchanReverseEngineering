.class public Lcom/redmadrobot/inputmask/helper/CaretStringIterator;
.super Ljava/lang/Object;
.source "CaretStringIterator.kt"


# instance fields
.field private final caretString:Lcom/redmadrobot/inputmask/model/CaretString;

.field private currentIndex:I


# direct methods
.method public constructor <init>(Lcom/redmadrobot/inputmask/model/CaretString;I)V
    .locals 1

    const-string v0, "caretString"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    .line 16
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;->caretString:Lcom/redmadrobot/inputmask/model/CaretString;

    iput p2, p0, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;->currentIndex:I

    return-void
.end method

.method public synthetic constructor <init>(Lcom/redmadrobot/inputmask/model/CaretString;IILkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 0

    and-int/lit8 p3, p3, 0x2

    if-eqz p3, :cond_0

    const/4 p2, 0x0

    .line 18
    :cond_0
    invoke-direct {p0, p1, p2}, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;-><init>(Lcom/redmadrobot/inputmask/model/CaretString;I)V

    return-void
.end method


# virtual methods
.method public deletionAffectsCaret()Z
    .locals 2

    .line 30
    iget v0, p0, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;->currentIndex:I

    iget-object v1, p0, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;->caretString:Lcom/redmadrobot/inputmask/model/CaretString;

    invoke-virtual {v1}, Lcom/redmadrobot/inputmask/model/CaretString;->getCaretPosition()I

    move-result v1

    if-ge v0, v1, :cond_0

    const/4 v0, 0x1

    return v0

    :cond_0
    const/4 v0, 0x0

    return v0
.end method

.method protected final getCaretString()Lcom/redmadrobot/inputmask/model/CaretString;
    .locals 1

    .line 17
    iget-object v0, p0, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;->caretString:Lcom/redmadrobot/inputmask/model/CaretString;

    return-object v0
.end method

.method protected final getCurrentIndex()I
    .locals 1

    .line 18
    iget v0, p0, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;->currentIndex:I

    return v0
.end method

.method public insertionAffectsCaret()Z
    .locals 4

    .line 22
    iget-object v0, p0, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;->caretString:Lcom/redmadrobot/inputmask/model/CaretString;

    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/model/CaretString;->getCaretGravity()Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity;

    move-result-object v0

    .line 23
    instance-of v1, v0, Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity$BACKWARD;

    const/4 v2, 0x0

    const/4 v3, 0x1

    if-eqz v1, :cond_1

    iget v0, p0, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;->currentIndex:I

    iget-object v1, p0, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;->caretString:Lcom/redmadrobot/inputmask/model/CaretString;

    invoke-virtual {v1}, Lcom/redmadrobot/inputmask/model/CaretString;->getCaretPosition()I

    move-result v1

    if-ge v0, v1, :cond_0

    return v3

    :cond_0
    return v2

    .line 24
    :cond_1
    instance-of v0, v0, Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity$FORWARD;

    if-eqz v0, :cond_4

    .line 25
    iget v0, p0, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;->currentIndex:I

    iget-object v1, p0, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;->caretString:Lcom/redmadrobot/inputmask/model/CaretString;

    invoke-virtual {v1}, Lcom/redmadrobot/inputmask/model/CaretString;->getCaretPosition()I

    move-result v1

    if-le v0, v1, :cond_3

    iget v0, p0, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;->currentIndex:I

    if-nez v0, :cond_2

    iget-object v0, p0, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;->caretString:Lcom/redmadrobot/inputmask/model/CaretString;

    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/model/CaretString;->getCaretPosition()I

    move-result v0

    if-nez v0, :cond_2

    goto :goto_0

    :cond_2
    return v2

    :cond_3
    :goto_0
    return v3

    :cond_4
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/NoWhenBranchMatchedException;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/NoWhenBranchMatchedException;-><init>()V

    throw v0
.end method

.method public next()Ljava/lang/Character;
    .locals 2

    .line 39
    iget v0, p0, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;->currentIndex:I

    iget-object v1, p0, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;->caretString:Lcom/redmadrobot/inputmask/model/CaretString;

    invoke-virtual {v1}, Lcom/redmadrobot/inputmask/model/CaretString;->getString()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/String;->length()I

    move-result v1

    if-lt v0, v1, :cond_0

    const/4 v0, 0x0

    return-object v0

    .line 43
    :cond_0
    iget-object v0, p0, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;->caretString:Lcom/redmadrobot/inputmask/model/CaretString;

    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/model/CaretString;->getString()Ljava/lang/String;

    move-result-object v0

    if-eqz v0, :cond_1

    invoke-virtual {v0}, Ljava/lang/String;->toCharArray()[C

    move-result-object v0

    const-string v1, "(this as java.lang.String).toCharArray()"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkExpressionValueIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    iget v1, p0, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;->currentIndex:I

    aget-char v0, v0, v1

    add-int/lit8 v1, v1, 0x1

    .line 44
    iput v1, p0, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;->currentIndex:I

    .line 45
    invoke-static {v0}, Ljava/lang/Character;->valueOf(C)Ljava/lang/Character;

    move-result-object v0

    return-object v0

    .line 43
    :cond_1
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/TypeCastException;

    const-string v1, "null cannot be cast to non-null type java.lang.String"

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/TypeCastException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method protected final setCurrentIndex(I)V
    .locals 0

    .line 18
    iput p1, p0, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;->currentIndex:I

    return-void
.end method
