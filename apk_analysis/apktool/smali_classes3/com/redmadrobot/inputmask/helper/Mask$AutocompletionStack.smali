.class final Lcom/redmadrobot/inputmask/helper/Mask$AutocompletionStack;
.super Ljava/util/Stack;
.source "Mask.kt"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/redmadrobot/inputmask/helper/Mask;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1a
    name = "AutocompletionStack"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/util/Stack<",
        "Lcom/redmadrobot/inputmask/model/Next;",
        ">;"
    }
.end annotation


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 360
    invoke-direct {p0}, Ljava/util/Stack;-><init>()V

    return-void
.end method


# virtual methods
.method public bridge contains(Lcom/redmadrobot/inputmask/model/Next;)Z
    .locals 0

    .line 360
    invoke-super {p0, p1}, Ljava/util/AbstractCollection;->contains(Ljava/lang/Object;)Z

    move-result p1

    return p1
.end method

.method public final bridge contains(Ljava/lang/Object;)Z
    .locals 1

    if-eqz p1, :cond_0

    .line 360
    instance-of v0, p1, Lcom/redmadrobot/inputmask/model/Next;

    goto :goto_0

    :cond_0
    const/4 v0, 0x1

    :goto_0
    if-eqz v0, :cond_1

    check-cast p1, Lcom/redmadrobot/inputmask/model/Next;

    invoke-virtual {p0, p1}, Lcom/redmadrobot/inputmask/helper/Mask$AutocompletionStack;->contains(Lcom/redmadrobot/inputmask/model/Next;)Z

    move-result p1

    return p1

    :cond_1
    const/4 p1, 0x0

    return p1
.end method

.method public bridge getSize()I
    .locals 1

    .line 360
    invoke-super {p0}, Ljava/util/AbstractCollection;->size()I

    move-result v0

    return v0
.end method

.method public bridge indexOf(Lcom/redmadrobot/inputmask/model/Next;)I
    .locals 0

    .line 360
    invoke-super {p0, p1}, Ljava/util/AbstractList;->indexOf(Ljava/lang/Object;)I

    move-result p1

    return p1
.end method

.method public final bridge indexOf(Ljava/lang/Object;)I
    .locals 1

    if-eqz p1, :cond_0

    .line 360
    instance-of v0, p1, Lcom/redmadrobot/inputmask/model/Next;

    goto :goto_0

    :cond_0
    const/4 v0, 0x1

    :goto_0
    if-eqz v0, :cond_1

    check-cast p1, Lcom/redmadrobot/inputmask/model/Next;

    invoke-virtual {p0, p1}, Lcom/redmadrobot/inputmask/helper/Mask$AutocompletionStack;->indexOf(Lcom/redmadrobot/inputmask/model/Next;)I

    move-result p1

    return p1

    :cond_1
    const/4 p1, -0x1

    return p1
.end method

.method public bridge lastIndexOf(Lcom/redmadrobot/inputmask/model/Next;)I
    .locals 0

    .line 360
    invoke-super {p0, p1}, Ljava/util/AbstractList;->lastIndexOf(Ljava/lang/Object;)I

    move-result p1

    return p1
.end method

.method public final bridge lastIndexOf(Ljava/lang/Object;)I
    .locals 1

    if-eqz p1, :cond_0

    .line 360
    instance-of v0, p1, Lcom/redmadrobot/inputmask/model/Next;

    goto :goto_0

    :cond_0
    const/4 v0, 0x1

    :goto_0
    if-eqz v0, :cond_1

    check-cast p1, Lcom/redmadrobot/inputmask/model/Next;

    invoke-virtual {p0, p1}, Lcom/redmadrobot/inputmask/helper/Mask$AutocompletionStack;->lastIndexOf(Lcom/redmadrobot/inputmask/model/Next;)I

    move-result p1

    return p1

    :cond_1
    const/4 p1, -0x1

    return p1
.end method

.method public push(Lcom/redmadrobot/inputmask/model/Next;)Lcom/redmadrobot/inputmask/model/Next;
    .locals 0

    if-eqz p1, :cond_0

    .line 363
    invoke-super {p0, p1}, Ljava/util/Stack;->push(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/redmadrobot/inputmask/model/Next;

    return-object p1

    .line 365
    :cond_0
    invoke-virtual {p0}, Ljava/util/Vector;->removeAllElements()V

    const/4 p1, 0x0

    return-object p1
.end method

.method public bridge synthetic push(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 360
    check-cast p1, Lcom/redmadrobot/inputmask/model/Next;

    invoke-virtual {p0, p1}, Lcom/redmadrobot/inputmask/helper/Mask$AutocompletionStack;->push(Lcom/redmadrobot/inputmask/model/Next;)Lcom/redmadrobot/inputmask/model/Next;

    move-result-object p1

    return-object p1
.end method

.method public final bridge remove(I)Lcom/redmadrobot/inputmask/model/Next;
    .locals 0

    .line 360
    invoke-virtual {p0, p1}, Lcom/redmadrobot/inputmask/helper/Mask$AutocompletionStack;->removeAt(I)Lcom/redmadrobot/inputmask/model/Next;

    move-result-object p1

    return-object p1
.end method

.method public bridge remove(Lcom/redmadrobot/inputmask/model/Next;)Z
    .locals 0

    .line 360
    invoke-super {p0, p1}, Ljava/util/AbstractCollection;->remove(Ljava/lang/Object;)Z

    move-result p1

    return p1
.end method

.method public final bridge remove(Ljava/lang/Object;)Z
    .locals 1

    if-eqz p1, :cond_0

    .line 360
    instance-of v0, p1, Lcom/redmadrobot/inputmask/model/Next;

    goto :goto_0

    :cond_0
    const/4 v0, 0x1

    :goto_0
    if-eqz v0, :cond_1

    check-cast p1, Lcom/redmadrobot/inputmask/model/Next;

    invoke-virtual {p0, p1}, Lcom/redmadrobot/inputmask/helper/Mask$AutocompletionStack;->remove(Lcom/redmadrobot/inputmask/model/Next;)Z

    move-result p1

    return p1

    :cond_1
    const/4 p1, 0x0

    return p1
.end method

.method public bridge removeAt(I)Lcom/redmadrobot/inputmask/model/Next;
    .locals 0

    .line 360
    invoke-super {p0, p1}, Ljava/util/AbstractList;->remove(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/redmadrobot/inputmask/model/Next;

    return-object p1
.end method

.method public final bridge size()I
    .locals 1

    .line 360
    invoke-virtual {p0}, Lcom/redmadrobot/inputmask/helper/Mask$AutocompletionStack;->getSize()I

    move-result v0

    return v0
.end method
