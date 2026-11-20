.class public final Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;
.super Ljava/lang/Object;
.source "MaskedTextChangedListener.kt"


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->pickMask(Lcom/redmadrobot/inputmask/model/CaretString;)Lcom/redmadrobot/inputmask/helper/Mask;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "MaskAffinity"
.end annotation


# instance fields
.field private final affinity:I

.field private final mask:Lcom/redmadrobot/inputmask/helper/Mask;


# direct methods
.method public constructor <init>(Lcom/redmadrobot/inputmask/helper/Mask;I)V
    .locals 1

    const-string v0, "mask"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    .line 247
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;->mask:Lcom/redmadrobot/inputmask/helper/Mask;

    iput p2, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;->affinity:I

    return-void
.end method

.method public static synthetic copy$default(Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;Lcom/redmadrobot/inputmask/helper/Mask;IILjava/lang/Object;)Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;
    .locals 0

    .line 0
    and-int/lit8 p4, p3, 0x1

    if-eqz p4, :cond_0

    iget-object p1, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;->mask:Lcom/redmadrobot/inputmask/helper/Mask;

    :cond_0
    and-int/lit8 p3, p3, 0x2

    if-eqz p3, :cond_1

    iget p2, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;->affinity:I

    :cond_1
    invoke-virtual {p0, p1, p2}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;->copy(Lcom/redmadrobot/inputmask/helper/Mask;I)Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;

    move-result-object p0

    return-object p0
.end method


# virtual methods
.method public final component1()Lcom/redmadrobot/inputmask/helper/Mask;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;->mask:Lcom/redmadrobot/inputmask/helper/Mask;

    return-object v0
.end method

.method public final component2()I
    .locals 1

    .line 0
    iget v0, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;->affinity:I

    return v0
.end method

.method public final copy(Lcom/redmadrobot/inputmask/helper/Mask;I)Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;
    .locals 1

    .line 0
    const-string v0, "mask"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;

    invoke-direct {v0, p1, p2}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;-><init>(Lcom/redmadrobot/inputmask/helper/Mask;I)V

    return-object v0
.end method

.method public equals(Ljava/lang/Object;)Z
    .locals 2

    .line 0
    if-eq p0, p1, :cond_1

    instance-of v0, p1, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;

    if-eqz v0, :cond_0

    check-cast p1, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;

    iget-object v0, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;->mask:Lcom/redmadrobot/inputmask/helper/Mask;

    iget-object v1, p1, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;->mask:Lcom/redmadrobot/inputmask/helper/Mask;

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    iget v0, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;->affinity:I

    iget p1, p1, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;->affinity:I

    if-ne v0, p1, :cond_0

    goto :goto_0

    :cond_0
    const/4 p1, 0x0

    return p1

    :cond_1
    :goto_0
    const/4 p1, 0x1

    return p1
.end method

.method public final getAffinity()I
    .locals 1

    .line 247
    iget v0, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;->affinity:I

    return v0
.end method

.method public final getMask()Lcom/redmadrobot/inputmask/helper/Mask;
    .locals 1

    .line 247
    iget-object v0, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;->mask:Lcom/redmadrobot/inputmask/helper/Mask;

    return-object v0
.end method

.method public hashCode()I
    .locals 2

    .line 0
    iget-object v0, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;->mask:Lcom/redmadrobot/inputmask/helper/Mask;

    if-eqz v0, :cond_0

    invoke-virtual {v0}, Ljava/lang/Object;->hashCode()I

    move-result v0

    goto :goto_0

    :cond_0
    const/4 v0, 0x0

    :goto_0
    mul-int/lit8 v0, v0, 0x1f

    iget v1, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;->affinity:I

    add-int/2addr v0, v1

    return v0
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    .line 0
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "MaskAffinity(mask="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;->mask:Lcom/redmadrobot/inputmask/helper/Mask;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", affinity="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget v1, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;->affinity:I

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v1, ")"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
